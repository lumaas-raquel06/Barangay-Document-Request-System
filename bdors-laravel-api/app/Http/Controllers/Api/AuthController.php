<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class AuthController extends Controller
{
    public function login(Request $request)
    {
        $user = DB::table('admin')
            ->where('username', $request->username)
            ->first();

        if (!$user)
        {
            return response()->json([
                'success' => false,
                'message' => 'Username not found'
            ],401);
        }

        if (!Hash::check($request->password, $user->password))
        {
            return response()->json([
                'success' => false,
                'message' => 'Wrong password'
            ],401);
        }

        return response()->json([
            'success' => true,
            'message' => 'Login successful',
            'user' => $user
        ]);
    }
}