//* SOLID
// C# basic design principles
//* S -> single responsibility principle
// everything has ONE job (should NOT say "this does x AND y")
//* O -> open closed principle
// open for extension, closed for modification
// behavior can be extended without modifying the source code
// interface is common open close practice
//* L -> Liskov substitution principle
// an object may be replaced by a sub-object without breaking the program
// allows subclass to be more specific
//* I -> interface segragation principle
// classes only able to perform behaviors useful to attain end functionality
// don't take behaviors they don't use
// less code = fewer bugs
//* D -> dependency inversion principle
// High-level modules should not import anything from low-level modules. 
// Both should depend on abstractions (ex: interfaces)
// Abstractions should not depend on details. Details (concrete implementations) should depend on abstractions.
////-------------------------------------------------------------------------------------------------------------
//* UI => user interface

using StreamingContentUI;

ProgramUI ui = new ProgramUI();

ui.Run();
