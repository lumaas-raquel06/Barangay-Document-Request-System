<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class ResidentController extends Controller
{
    public function index(Request $request)
    {
        $status = $request->query('status', 'Active');

        $residents = DB::table('tbl_residentinfo as r')
            ->leftJoin('user_resident as u', 'r.residentId', '=', 'u.residentId')
            ->select(
                'r.residentId',
                'r.fname',
                'r.mname',
                'r.lname',
                'r.ext',
                'r.placeOfBirth',
                'r.age',
                'r.gender',
                'r.bday',
                'r.isVoter',
                'r.civilStatus',
                'r.nationality',
                'r.contact',
                'r.status',
                'r.houseNumber',
                'r.block',
                'r.lot',
                'r.streetName',
                'r.areaType',
                'u.username',
                'u.email'
            )
            ->where('r.status', $status)
            ->orderBy('r.residentId', 'desc')
            ->get();

        return response()->json([
            'success' => true,
            'data' => $residents
        ]);
    }

    public function show($residentId)
    {
        $resident = DB::table('tbl_residentinfo as r')
            ->leftJoin('user_resident as u', 'r.residentId', '=', 'u.residentId')
            ->select(
                'r.residentId',
                'r.fname',
                'r.mname',
                'r.lname',
                'r.ext',
                'r.placeOfBirth',
                'r.age',
                'r.gender',
                'r.bday',
                'r.isVoter',
                'r.civilStatus',
                'r.nationality',
                'r.contact',
                'r.status',
                'r.houseNumber',
                'r.block',
                'r.lot',
                'r.streetName',
                'r.areaType',
                'u.username',
                'u.email'
            )
            ->where('r.residentId', $residentId)
            ->first();

        if (!$resident) {
            return response()->json([
                'success' => false,
                'message' => 'Resident not found.'
            ], 404);
        }

        return response()->json([
            'success' => true,
            'data' => $resident
        ]);
    }

    public function store(Request $request)
    {
        DB::beginTransaction();

        try {
            DB::table('tbl_residentinfo')->insert([
                'residentId' => $request->residentId,
                'fname' => $request->fname,
                'mname' => $request->mname,
                'lname' => $request->lname,
                'ext' => $request->ext,
                'placeOfBirth' => $request->placeOfBirth,
                'age' => $request->age,
                'gender' => $request->gender,
                'bday' => $request->bday,
                'isVoter' => $request->isVoter,
                'civilStatus' => $request->civilStatus,
                'nationality' => $request->nationality,
                'contact' => $request->contact,
                'status' => $request->status ?? 'Active',
                'houseNumber' => $request->houseNumber,
                'block' => $request->block,
                'lot' => $request->lot,
                'streetName' => $request->streetName,
                'areaType' => $request->areaType
            ]);

            DB::table('user_resident')->insert([
                'residentId' => $request->residentId,
                'username' => $request->username,
                'password' => Hash::make($request->password),
                'email' => $request->email,
                'reset_token' => null,
                'reset_expiry' => null
            ]);

            DB::commit();

            return response()->json([
                'success' => true,
                'message' => 'Resident saved successfully.'
            ]);
        } catch (\Exception $e) {
            DB::rollBack();

            return response()->json([
                'success' => false,
                'message' => 'Failed to save resident.',
                'error' => $e->getMessage()
            ], 500);
        }
    }

    public function update(Request $request, $residentId)
    {
        DB::beginTransaction();

        try {
            DB::table('tbl_residentinfo')
                ->where('residentId', $residentId)
                ->update([
                    'fname' => $request->fname,
                    'mname' => $request->mname,
                    'lname' => $request->lname,
                    'ext' => $request->ext,
                    'placeOfBirth' => $request->placeOfBirth,
                    'age' => $request->age,
                    'gender' => $request->gender,
                    'bday' => $request->bday,
                    'isVoter' => $request->isVoter,
                    'civilStatus' => $request->civilStatus,
                    'nationality' => $request->nationality,
                    'contact' => $request->contact,
                    'houseNumber' => $request->houseNumber,
                    'block' => $request->block,
                    'lot' => $request->lot,
                    'streetName' => $request->streetName,
                    'areaType' => $request->areaType
                ]);

            if ($request->has('email')) {
                DB::table('user_resident')
                    ->where('residentId', $residentId)
                    ->update([
                        'email' => $request->email
                    ]);
            }

            DB::commit();

            return response()->json([
                'success' => true,
                'message' => 'Resident updated successfully.'
            ]);
        } catch (\Exception $e) {
            DB::rollBack();

            return response()->json([
                'success' => false,
                'message' => 'Failed to update resident.',
                'error' => $e->getMessage()
            ], 500);
        }
    }

    public function updateStatus(Request $request, $residentId)
    {
        $updated = DB::table('tbl_residentinfo')
            ->where('residentId', $residentId)
            ->update([
                'status' => $request->status
            ]);

        if ($updated === 0) {
            return response()->json([
                'success' => false,
                'message' => 'No changes made. Resident may not exist.'
            ], 404);
        }

        return response()->json([
            'success' => true,
            'message' => 'Resident status updated successfully.'
        ]);
    }

    public function destroy($residentId)
    {
        DB::beginTransaction();

        try {
            DB::table('user_resident')
                ->where('residentId', $residentId)
                ->delete();

            DB::table('tbl_residentinfo')
                ->where('residentId', $residentId)
                ->delete();

            DB::commit();

            return response()->json([
                'success' => true,
                'message' => 'Resident deleted successfully.'
            ]);
        } catch (\Exception $e) {
            DB::rollBack();

            return response()->json([
                'success' => false,
                'message' => 'Failed to delete resident.',
                'error' => $e->getMessage()
            ], 500);
        }
    }
}