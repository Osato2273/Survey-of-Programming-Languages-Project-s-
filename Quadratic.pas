program QuadraticEquation;

uses
  Math, SysUtils;

procedure FindRoots(a, b, c: Real; var root1, root2: Real; var rootType: String);
var
  discriminant: Real;
begin
  discriminant := b * b - 4 * a * c;

  if discriminant > 0 then
  begin
    // Two distinct real roots
    root1 := (-b + Sqrt(discriminant)) / (2 * a);
    root2 := (-b - Sqrt(discriminant)) / (2 * a);
    rootType := 'two distinct real roots';
  end
  else if discriminant = 0 then
  begin
    // One real root (repeated root)
    root1 := -b / (2 * a);
    root2 := root1;
    rootType := 'one repeated real root';
  end
  else
  begin
    // Two complex roots
    root1 := -b / (2 * a);
    root2 := Sqrt(-discriminant) / (2 * a);
    rootType := 'two complex roots';
  end;
end;

var
  a, b, c: Real;
  root1, root2: Real;
  rootType: String;

begin
  // Prompt the user to enter the coefficients
  Write('Enter the coefficient a (a should not be zero): ');
  ReadLn(a);
  while a = 0 do
  begin
    Write('Coefficient a cannot be zero. Please enter a valid value for a: ');
    ReadLn(a);
  end;

  Write('Enter the coefficient b: ');
  ReadLn(b);

  Write('Enter the coefficient c: ');
  ReadLn(c);

  // Find the roots and the type of roots
  FindRoots(a, b, c, root1, root2, rootType);

  // Display the results
  WriteLn(Format('The quadratic equation with coefficients a=%.2f, b=%.2f, c=%.2f has %s.', [a, b, c, rootType]));
  if rootType = 'two complex roots' then
  begin
    WriteLn(Format('The roots are: %.2f + %.2fi and %.2f - %.2fi', [root1, root2, root1, root2]));
  end
  else
  begin
    WriteLn(Format('The roots are: %.2f and %.2f', [root1, root2]));
  end;
end.

