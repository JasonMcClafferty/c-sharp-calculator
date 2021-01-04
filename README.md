Pseudocode:

    Functional:

        Add
        Subtract
        Multiply
        Divide
        
        Brackets

        Move Cursor Left
        Move Cursor Right
        Delete 1 char

        Equals/Enter

        Display
        Clear

    UI/UX

        Render
        
        Front Face of the Calculator
            Header Panel
                Screen
            Button Panel
                Number Panel
                    Number Buttons X 10
                Operand Panel
                    Operand Buttons X 5


    Non-Functional:

        Self-Documenting Method names
        SOLID
        Dependency Injection - make your dependency functions abstract enough to handle being injected into concrete classes.
            Eg. Instead of having a BookPrinter class, have your Printer class handle being called by a Book object.
        Inversion of Control
        
        Testing

        Refactoring: If you can extract a method from a method, you should.



    (i) Get the functionality working with the console.



    Classes:
        Result class stores and returns the result to the output
        Operation/Operand will have subclasses(+, -, /, *) using polymorphism to determine the operation called




