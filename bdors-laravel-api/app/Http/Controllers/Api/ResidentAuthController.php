<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class ResidentAuthController extends Controller
{
    public function login(Request $request)
    {
        $username = $request->username;
        $password = $request->password;

        if (empty($username) || empty($password)) {
            return response()->json([
                'success' => false,
                'message' => 'Username and password are required.'
            ], 400);
        }

        $resident = DB::table('user_resident as u')
            ->join('tbl_residentinfo as r', 'u.residentId', '=', 'r.residentId')
            ->select(
                'u.residentId',
                'u.username',
                'u.password',
                'u.email',
                'r.fname',
                'r.lname',
                'r.status'
            )
            ->where('u.username', $username)
            ->where('r.status', 'Active')
            ->first();

        if (!$resident) {
            return response()->json([
                'success' => false,
                'message' => 'Not registered in Brgy. Ayahag, Saint Bernard, Southern Leyte.'
            ], 401);
        }

        if (!Hash::check($password, $resident->password)) {
            return response()->json([
                'success' => false,
                'message' => 'Invalid credentials.'
            ], 401);
        }

        return response()->json([
            'success' => true,
            'message' => 'Login successful.',
            'data' => [
                'residentId' => $resident->residentId,
                'username' => $resident->username,
                'firstname' => $resident->fname,
                'lastname' => $resident->lname,
                'email' => $resident->email,
                'status' => $resident->status
            ]
        ]);
    }
}