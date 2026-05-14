<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\ResidentController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::get('/residents', [ResidentController::class, 'index']);
Route::post('/residents', [ResidentController::class, 'store']);
Route::put('/residents/{residentId}', [ResidentController::class, 'update']);
Route::delete('/residents/{residentId}', [ResidentController::class, 'destroy']);