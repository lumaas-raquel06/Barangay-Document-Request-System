<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ResidentController extends Controller
{
    public function index()
    {
        $residents = DB::table('tbl_residentinfo')
            ->select(
                'residentId',
                'fname',
                'mname',
                'lname',
                'ext',
                'placeOfBirth',
                'age',
                'gender',
                'bday',
                'isVoter',
                'civilStatus',
                'nationality',
                'contact',
                'status',
                'houseNumber',
                'block',
                'lot',
                'streetName',
                'areaType'
            )
            ->get();

        return response()->json([
            'success' => true,
            'data' => $residents
        ]);
    }

    public function store(Request $request)
    {
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
            'status' => $request->status,
            'houseNumber' => $request->houseNumber,
            'block' => $request->block,
            'lot' => $request->lot,
            'streetName' => $request->streetName,
            'areaType' => $request->areaType
        ]);

        return response()->json([
            'success' => true,
            'message' => 'Resident added successfully'
        ]);
    }

    public function update(Request $request, $residentId)
    {
        DB::table('tbl_residentinfo')
            ->where('residentId', $residentId)
            ->update([
                'fname' => $request->fname,
                'mname' => $request->mname,
                'lname' => $request->lname,
                'contact' => $request->contact,
                'status' => $request->status
            ]);

        return response()->json([
            'success' => true,
            'message' => 'Resident updated successfully'
        ]);
    }

    public function destroy($residentId)
    {
        DB::table('tbl_residentinfo')
            ->where('residentId', $residentId)
            ->delete();

        return response()->json([
            'success' => true,
            'message' => 'Resident deleted successfully'
        ]);
    }
}