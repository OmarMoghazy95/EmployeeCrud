import { FormArray, FormControl, FormGroup } from '@angular/forms';
export type ControlsOf<T extends Record<string, any>> = {
  [K in keyof T]: T[K] extends Date
    ? FormControl<Date | null> // Handle Date specifically
    : T[K] extends Array<infer U> // Handle arrays
      ? U extends Record<string, any> // Only apply recursion if U is an object
        ? FormArray<FormGroup<ControlsOf<U>>>
        : FormArray<FormControl<U>> // Otherwise, handle it as an array of FormControls
      : T[K] extends Record<string, any> // Handle nested objects
        ? FormGroup<ControlsOf<T[K]>>
        : FormControl; // Handle primitive types
};
