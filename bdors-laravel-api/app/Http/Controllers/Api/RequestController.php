<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class RequestController extends Controller
{
    public function index(Request $request)
    {
        $status = $request->query('status', 'Pending for Approval');
        $year = $request->query('year', date('Y'));
        $search = $request->query('search', '');

        $requests = DB::table('request')
            ->select(
                'id',
                'residentId',
                'Fullname',
                'Birthdate',
                'Age',
                'Gender',
                'HomeAddress',
                'Contact',
                'DateofRequest',
                'Purposes',
                'Documents',
                'Fee',
                'ValidID',
                'FrontID',
                'BackID',
                'Payment',
                'Service',
                'Status'
            )
            ->where('Status', $status)
            ->whereYear('DateofRequest', $year)
            ->where(function ($query) use ($search) {
                $query->where('Fullname', 'LIKE', '%' . $search . '%')
                    ->orWhere('Documents', 'LIKE', '%' . $search . '%');
            })
            ->orderBy('DateofRequest', 'desc')
            ->get();

        return response()->json([
            'success' => true,
            'data' => $requests
        ]);
    }

    public function store(Request $request)
    {
        try {
            DB::table('request')->insert([
                'residentId' => $request->residentId,
                'Fullname' => $request->Fullname,
                'Birthdate' => $request->Birthdate,
                'Age' => $request->Age,
                'Gender' => $request->Gender,
                'HomeAddress' => $request->HomeAddress,
                'Contact' => $request->Contact,
                'DateofRequest' => $request->DateofRequest ?? date('Y-m-d'),
                'Purposes' => $request->Purposes,
                'Documents' => $request->Documents,
                'Fee' => $request->Fee,
                'ValidID' => $request->ValidID,
                'FrontID' => $request->FrontID,
                'BackID' => $request->BackID,
                'Payment' => $request->Payment,
                'Service' => $request->Service,
                'Status' => $request->Status ?? 'Pending for Approval'
            ]);

            return response()->json([
                'success' => true,
                'message' => 'Document request submitted successfully.'
            ]);
        } catch (\Exception $e) {
            return response()->json([
                'success' => false,
                'message' => 'Failed to submit document request.',
                'error' => $e->getMessage()
            ], 500);
        }
    }

    public function updateStatus(Request $request, $id)
    {
        $updated = DB::table('request')
            ->where('id', $id)
            ->update([
                'Status' => $request->Status
            ]);

        if ($updated === 0) {
            return response()->json([
                'success' => false,
                'message' => 'No changes made. Request may not exist.'
            ], 404);
        }

        return response()->json([
            'success' => true,
            'message' => 'Request status updated successfully.'
        ]);
    }

    public function show($id)
    {
        $request = DB::table('request')
            ->leftJoin('user_resident', 'request.residentId', '=', 'user_resident.residentId')
            ->select(
                'request.*',
                'user_resident.email'
            )
            ->where('request.id', $id)
            ->first();

        if (!$request) {
            return response()->json([
                'success' => false,
                'message' => 'Request not found.'
            ], 404);
        }

        return response()->json([
            'success' => true,
            'data' => $request
        ]);
    }
}