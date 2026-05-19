<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Api\AuthController;
use App\Http\Controllers\Api\ResidentController;
use App\Http\Controllers\Api\RequestController;
use App\Http\Controllers\Api\ResidentAuthController;

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

/*
|--------------------------------------------------------------------------
| Admin Login API
|--------------------------------------------------------------------------
*/
Route::post('/login', [AuthController::class, 'login']);

/*
|--------------------------------------------------------------------------
| Resident API
|--------------------------------------------------------------------------
*/
Route::get('/residents', [ResidentController::class, 'index']);
Route::get('/residents/{residentId}', [ResidentController::class, 'show']);
Route::post('/residents', [ResidentController::class, 'store']);
Route::put('/residents/{residentId}', [ResidentController::class, 'update']);
Route::patch('/residents/{residentId}/status', [ResidentController::class, 'updateStatus']);
Route::delete('/residents/{residentId}', [ResidentController::class, 'destroy']);

/*
|--------------------------------------------------------------------------
| Resident Login API
|--------------------------------------------------------------------------
*/
Route::post('/resident/login', [ResidentAuthController::class, 'login']);

/*
|--------------------------------------------------------------------------
| Document Request API
|--------------------------------------------------------------------------
*/
Route::get('/requests', [RequestController::class, 'index']);
Route::post('/requests', [RequestController::class, 'store']);
Route::patch('/requests/{id}/status', [RequestController::class, 'updateStatus']);
Route::put('/residents/{residentId}', [ResidentController::class, 'update']);
Route::get('/requests/{id}', [RequestController::class, 'show']);
