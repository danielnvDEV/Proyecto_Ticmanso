#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
265,
277,
278,
279,
280,
281,
282,
283,
284,
285,
288,
289,
290,
467,
468,
469,
499,
500,
501,
521,
522,
523,
524,
641,
642,
643,
646,
699,
700,
701,
704,
706,
708,
710,
715,
723,
724,
725,
726,
727,
728,
729,
730,
731,
732,
733,
734,
735,
736,
737,
738,
739,
741,
742,
743,
744,
745,
746,
747,
845,
846,
847,
848,
849,
850,
851,
852,
853,
854,
855,
856,
857,
858,
859,
860,
861,
863,
864,
865,
866,
867,
868,
869,
936,
937,
1006,
1013,
1016,
1018,
1023,
1024,
1026,
1027,
1031,
1033,
1034,
1036,
1038,
1039,
1042,
1043,
1044,
1047,
1049,
1052,
1054,
1056,
1065,
1135,
1137,
1139,
1149,
1150,
1151,
1152,
1154,
1161,
1162,
1163,
1164,
1165,
1173,
1174,
1175,
1179,
1180,
1182,
1186,
1187,
1188,
1472,
1674,
1675,
10200,
10201,
10203,
10204,
10205,
10206,
10207,
10208,
10210,
10212,
10214,
10215,
10216,
10227,
10229,
10237,
10239,
10241,
10243,
10295,
10301,
10302,
10304,
10305,
10306,
10307,
10308,
10310,
10312,
11572,
11576,
11578,
11579,
11580,
11581,
11848,
11849,
11850,
11851,
11871,
11872,
11873,
11875,
11877,
11939,
12033,
12035,
12037,
12047,
12048,
12049,
12050,
12051,
12554,
12555,
12556,
12561,
12562,
12605,
12606,
12654,
12661,
12668,
12679,
12683,
12709,
12789,
12797,
12799,
12813,
12815,
12816,
12817,
12818,
12825,
12841,
12861,
12862,
12870,
12872,
12879,
12880,
12883,
12885,
12890,
12896,
12897,
12904,
12906,
12918,
12921,
12922,
12923,
12934,
12943,
12949,
12950,
12951,
12953,
12954,
12971,
12973,
12987,
13010,
13011,
13012,
13037,
13042,
13072,
13073,
13736,
13758,
13855,
13856,
14092,
14093,
14103,
14104,
14105,
14111,
14227,
14907,
14908,
15674,
15676,
15677,
15682,
15692,
17180,
17201,
17203,
17205,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
void ves_icall_System_Enum_InternalBoxEnum_raw (int,int,int64_t,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
void ves_icall_RuntimeType_GetInterfaceMapData_raw (int,int,int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_System_RuntimeType_AllocateValueType_raw (int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsComObject_raw (int,int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Decrement_Long (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Read_Long (int);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
void ves_icall_System_Threading_Thread_StartInternal_raw (int,int,int);
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
void ves_icall_System_Runtime_InteropServices_Marshal_PtrToStructureInternal_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetCallingAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
void ves_icall_System_Reflection_AssemblyName_FreeAssemblyName (int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetEntryPoint_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetReferencedAssemblies_raw (int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw (int,int);
void ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw (int,int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
int ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_CustomAttributeBuilder_GetBlob_raw (int,int,int,int,int,int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 265,
ves_icall_System_Array_InternalCreate,
// token 277,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 278,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 279,
ves_icall_System_Array_CanChangePrimitive,
// token 280,
ves_icall_System_Array_FastCopy,
// token 281,
ves_icall_System_Array_GetLengthInternal_raw,
// token 282,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 283,
ves_icall_System_Array_GetGenericValue_icall,
// token 284,
ves_icall_System_Array_GetValueImpl_raw,
// token 285,
ves_icall_System_Array_SetGenericValue_icall,
// token 288,
ves_icall_System_Array_SetValueImpl_raw,
// token 289,
ves_icall_System_Array_InitializeInternal_raw,
// token 290,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 467,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 468,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 469,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 499,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 500,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 501,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 521,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 522,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 523,
ves_icall_System_Enum_InternalGetCorElementType,
// token 524,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 641,
ves_icall_System_Environment_get_ProcessorCount,
// token 642,
ves_icall_System_Environment_get_TickCount,
// token 643,
ves_icall_System_Environment_get_TickCount64,
// token 646,
ves_icall_System_Environment_FailFast_raw,
// token 699,
ves_icall_System_GC_GetCollectionCount,
// token 700,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 701,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 704,
ves_icall_System_GC_SuppressFinalize_raw,
// token 706,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 708,
ves_icall_System_GC_GetGCMemoryInfo,
// token 710,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 715,
ves_icall_System_Object_MemberwiseClone_raw,
// token 723,
ves_icall_System_Math_Acos,
// token 724,
ves_icall_System_Math_Acosh,
// token 725,
ves_icall_System_Math_Asin,
// token 726,
ves_icall_System_Math_Asinh,
// token 727,
ves_icall_System_Math_Atan,
// token 728,
ves_icall_System_Math_Atan2,
// token 729,
ves_icall_System_Math_Atanh,
// token 730,
ves_icall_System_Math_Cbrt,
// token 731,
ves_icall_System_Math_Ceiling,
// token 732,
ves_icall_System_Math_Cos,
// token 733,
ves_icall_System_Math_Cosh,
// token 734,
ves_icall_System_Math_Exp,
// token 735,
ves_icall_System_Math_Floor,
// token 736,
ves_icall_System_Math_Log,
// token 737,
ves_icall_System_Math_Log10,
// token 738,
ves_icall_System_Math_Pow,
// token 739,
ves_icall_System_Math_Sin,
// token 741,
ves_icall_System_Math_Sinh,
// token 742,
ves_icall_System_Math_Sqrt,
// token 743,
ves_icall_System_Math_Tan,
// token 744,
ves_icall_System_Math_Tanh,
// token 745,
ves_icall_System_Math_FusedMultiplyAdd,
// token 746,
ves_icall_System_Math_Log2,
// token 747,
ves_icall_System_Math_ModF,
// token 845,
ves_icall_System_MathF_Acos,
// token 846,
ves_icall_System_MathF_Acosh,
// token 847,
ves_icall_System_MathF_Asin,
// token 848,
ves_icall_System_MathF_Asinh,
// token 849,
ves_icall_System_MathF_Atan,
// token 850,
ves_icall_System_MathF_Atan2,
// token 851,
ves_icall_System_MathF_Atanh,
// token 852,
ves_icall_System_MathF_Cbrt,
// token 853,
ves_icall_System_MathF_Ceiling,
// token 854,
ves_icall_System_MathF_Cos,
// token 855,
ves_icall_System_MathF_Cosh,
// token 856,
ves_icall_System_MathF_Exp,
// token 857,
ves_icall_System_MathF_Floor,
// token 858,
ves_icall_System_MathF_Log,
// token 859,
ves_icall_System_MathF_Log10,
// token 860,
ves_icall_System_MathF_Pow,
// token 861,
ves_icall_System_MathF_Sin,
// token 863,
ves_icall_System_MathF_Sinh,
// token 864,
ves_icall_System_MathF_Sqrt,
// token 865,
ves_icall_System_MathF_Tan,
// token 866,
ves_icall_System_MathF_Tanh,
// token 867,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 868,
ves_icall_System_MathF_Log2,
// token 869,
ves_icall_System_MathF_ModF,
// token 936,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 937,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 1006,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 1013,
ves_icall_RuntimeType_make_array_type_raw,
// token 1016,
ves_icall_RuntimeType_make_byref_type_raw,
// token 1018,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 1023,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 1024,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 1026,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 1027,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 1031,
ves_icall_RuntimeType_GetInterfaceMapData_raw,
// token 1033,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 1034,
ves_icall_System_RuntimeType_AllocateValueType_raw,
// token 1036,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 1038,
ves_icall_System_RuntimeType_getFullName_raw,
// token 1039,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 1042,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 1043,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 1044,
ves_icall_RuntimeType_GetFields_native_raw,
// token 1047,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 1049,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 1052,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 1054,
ves_icall_RuntimeType_GetName_raw,
// token 1056,
ves_icall_RuntimeType_GetNamespace_raw,
// token 1065,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1135,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1137,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1139,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1149,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1150,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1151,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 1152,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1154,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1161,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1162,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1163,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1164,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1165,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1173,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1174,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1175,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1179,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1180,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1182,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1186,
ves_icall_System_String_FastAllocateString_raw,
// token 1187,
ves_icall_System_String_InternalIsInterned_raw,
// token 1188,
ves_icall_System_String_InternalIntern_raw,
// token 1472,
ves_icall_System_Type_internal_from_handle_raw,
// token 1674,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1675,
ves_icall_System_ValueType_Equals_raw,
// token 10200,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 10201,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 10203,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 10204,
ves_icall_System_Threading_Interlocked_Decrement_Long,
// token 10205,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 10206,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 10207,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 10208,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 10210,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 10212,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 10214,
ves_icall_System_Threading_Interlocked_Read_Long,
// token 10215,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 10216,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 10227,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 10229,
mono_monitor_exit_icall_raw,
// token 10237,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 10239,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 10241,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 10243,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 10295,
ves_icall_System_Threading_Thread_StartInternal_raw,
// token 10301,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 10302,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 10304,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 10305,
ves_icall_System_Threading_Thread_GetState_raw,
// token 10306,
ves_icall_System_Threading_Thread_SetState_raw,
// token 10307,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 10308,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 10310,
ves_icall_System_Threading_Thread_YieldInternal,
// token 10312,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 11572,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 11576,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 11578,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 11579,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 11580,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 11581,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 11848,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 11849,
ves_icall_System_GCHandle_InternalFree_raw,
// token 11850,
ves_icall_System_GCHandle_InternalGet_raw,
// token 11851,
ves_icall_System_GCHandle_InternalSet_raw,
// token 11871,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 11872,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 11873,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 11875,
ves_icall_System_Runtime_InteropServices_Marshal_PtrToStructureInternal_raw,
// token 11877,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 11939,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 12033,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 12035,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw,
// token 12037,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 12047,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 12048,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 12049,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 12050,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw,
// token 12051,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 12554,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 12555,
ves_icall_System_Reflection_Assembly_GetCallingAssembly_raw,
// token 12556,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 12561,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 12562,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 12605,
ves_icall_System_Reflection_AssemblyName_FreeAssemblyName,
// token 12606,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 12654,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 12661,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 12668,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 12679,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 12683,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 12709,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 12789,
ves_icall_System_Reflection_RuntimeAssembly_GetEntryPoint_raw,
// token 12797,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 12799,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 12813,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 12815,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 12816,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 12817,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 12818,
ves_icall_System_Reflection_Assembly_InternalGetReferencedAssemblies_raw,
// token 12825,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 12841,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 12861,
ves_icall_reflection_get_token_raw,
// token 12862,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 12870,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 12872,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 12879,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 12880,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 12883,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 12885,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 12890,
ves_icall_reflection_get_token_raw,
// token 12896,
ves_icall_get_method_info_raw,
// token 12897,
ves_icall_get_method_attributes,
// token 12904,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 12906,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 12918,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 12921,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 12922,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 12923,
ves_icall_reflection_get_token_raw,
// token 12934,
ves_icall_InternalInvoke_raw,
// token 12943,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 12949,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 12950,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 12951,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 12953,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 12954,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 12971,
ves_icall_InvokeClassConstructor_raw,
// token 12973,
ves_icall_InternalInvoke_raw,
// token 12987,
ves_icall_reflection_get_token_raw,
// token 13010,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 13011,
ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw,
// token 13012,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 13037,
ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw,
// token 13042,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 13072,
ves_icall_reflection_get_token_raw,
// token 13073,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 13736,
ves_icall_CustomAttributeBuilder_GetBlob_raw,
// token 13758,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 13855,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 13856,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 14092,
ves_icall_ModuleBuilder_basic_init_raw,
// token 14093,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 14103,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 14104,
ves_icall_ModuleBuilder_getToken_raw,
// token 14105,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 14111,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 14227,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 14907,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 14908,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 15674,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 15676,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 15677,
ves_icall_System_Diagnostics_Debugger_Log,
// token 15682,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 15692,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 17180,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 17201,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 17203,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 17205,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
};
