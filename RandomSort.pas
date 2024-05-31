program SortingAndSearching;

uses
  SysUtils;

const
  SIZE = 25;
  MAX_VALUE = 100;

type
  TIntArray = array[1..SIZE] of Integer;

var
  arr: TIntArray;
  k: Integer;

procedure GenerateRandomNumbers(var arr: TIntArray);
var
  i: Integer;
begin
  Randomize;
  for i := 1 to SIZE do
    arr[i] := Random(MAX_VALUE) + 1;
end;

procedure PrintArray(arr: TIntArray);
var
  i: Integer;
begin
  for i := 1 to SIZE do
    Write(arr[i], ' ');
  WriteLn;
end;

procedure RadixSort(var arr: TIntArray);
var
  bucket: array[0..9, 1..SIZE] of Integer;
  bucketCount: array[0..9] of Integer;
  max, exp, i, j, k, digit: Integer;
begin
  max := arr[1];
  for i := 2 to SIZE do
    if arr[i] > max then
      max := arr[i];

  exp := 1;
  while max div exp > 0 do
  begin
    FillChar(bucketCount, SizeOf(bucketCount), 0);

    for i := 1 to SIZE do
    begin
      digit := (arr[i] div exp) mod 10;
      Inc(bucketCount[digit]);
      bucket[digit, bucketCount[digit]] := arr[i];
    end;

    k := 1;
    for i := 9 downto 0 do
      for j := 1 to bucketCount[i] do
      begin
        arr[k] := bucket[i, j];
        Inc(k);
      end;

    exp := exp * 10;
  end;
end;

procedure BubbleSort(var arr: TIntArray);
var
  i, j, temp: Integer;
  swapped: Boolean;
begin
  for i := 1 to SIZE - 1 do
  begin
    swapped := False;
    for j := 1 to SIZE - i do
      if arr[j] > arr[j + 1] then
      begin
        temp := arr[j];
        arr[j] := arr[j + 1];
        arr[j + 1] := temp;
        swapped := True;
      end;
    if not swapped then
      Break;
  end;
end;

function BinarySearch(arr: TIntArray; k: Integer): Integer;
var
  low, high, mid: Integer;
begin
  low := 1;
  high := SIZE;
  while low <= high do
  begin
    mid := (low + high) div 2;
    if arr[mid] = k then
    begin
      BinarySearch := mid;
      Exit;
    end;
    if arr[mid] < k then
      low := mid + 1
    else
      high := mid - 1;
  end;
  BinarySearch := -1;
end;

begin
  // Generate random numbers
  GenerateRandomNumbers(arr);
  WriteLn('Random Numbers:');
  PrintArray(arr);

  // Sort the array in descending order using Radix Sort
  RadixSort(arr);
  WriteLn('Sorted in descending order using Radix Sort:');
  PrintArray(arr);

  // Sort the array in ascending order using Bubble Sort
  BubbleSort(arr);
  WriteLn('Sorted in ascending order using Bubble Sort:');
  PrintArray(arr);

  // Prompt the user to enter the number to search for
  Write('Enter the number to search for: ');
  ReadLn(k);

  // Perform binary search
  if BinarySearch(arr, k) <> -1 then
    WriteLn('Number ', k, ' found in the array.')
  else
    WriteLn('Number ', k, ' not found in the array.');
end.
