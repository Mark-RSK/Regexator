# Regexator
Regexator project contains libraries that extends .NET regular expressions.

## LINQ to Regex
LINQ to Regex library provides language integrated access to the .NET regular expressions.

####Benefits
* Ability to create complex expressions while keeping readability and maintainability.
* Characters escaping.
  * Metacharacters that should be handled as a literals are escaped by the library.
* .NET regular expressions syntax knowledge is not required.
  * You don't have to remember regex syntax. Nevertheless you should be familiar with .NET regular expressions basics.

### Namespaces
```c#
Pihrtsoft.Text.RegularExpressions.Linq;
Pihrtsoft.Text.RegularExpressions.Linq.Extensions;
```
First namespace is a library root namespace. Second namespace contains static classes with extensions methods that extends existing .NET types are placed in the following namespace:

### Pattern class
The very base library type is the **Pattern** class that represent an immutable regular expression pattern.
Another very important type is the **Patterns** class. This static class returns instances of various kinds of **Pattern** class or its derived types.
When you want to create a pattern you have start with **Patterns** class.
```c#
Pattern pattern = Patterns.Digit();
```

### CharGrouping class

**CharGrouping** represents a content of a character group. **CharGrouping** can be created using **CharGroupings** static class that has the same purpose as **Patterns** class.

### Object or Object[]  parameter
A lot of methods that returns instance of the **Pattern** class accepts parameters of type **Object** and it is usually named **content**.
This methods accepts following types (types as **Object**):
* Pattern
* CharGrouping
* String
* Char
* Object[]
* IEnumerable

Last two items in the list, **Object[]** and **IEnumerable** can contains zero or more items (patterns) any one of which has to be matched.

Methods that allows to pass a content typed as **Object** usually allows to pass an array of object with **params** (**ParamArray** in VB) keyword. This overload simply convert the array of object to the object and calls overload that accept object as an argument. 

### Operators overloading
#### + Operator
Patterns can be concatenated using **+** operator.

```c#
Pattern pattern1 = Patterns.BeginLine() + Patterns.Assert(Patterns.NewLine());

//Or you can use Pattern.Assert instance  method to achieve the same goal.
Pattern pattern2 = Patterns.BeginLine().Assert(Patterns.NewLine());
```

#### - Operator
You can create character subtraction using **-** operator. It is defined for **CharGroup**, **CharGrouping** and **CharPattern** types.

```c#
CharSubtraction subtraction1 = Patterns.WhiteSpace() - CharGroupings.CarriageReturn().Linefeed();

//Or you can use IBaseGroup.Except method to achieve the same goal.
CharSubtraction subtraction2 = Patterns.WhiteSpace().Except(CharGroupings.CarriageReturn().Linefeed());

//In fact this pattern is very common so there is a direct support for it.
CharSubtraction subtraction3 = Patterns.WhiteSpaceExceptNewLine();
```

#### | Operator
**|** Operator combines two patterns into a group in which any of two patterns has to be matched.

```c#
Pattern pattern = Pattern.Group("first" | "second");

//Or you can use another method overload to achieve the same goal.
Pattern pattern = Pattern.Group("first", "second");
```

#### ! Operator

**!** operator is used to create pattern that has opposite meaning than operand.

```c#
//This pattern represents a linefeed that is not preceded with a carriage return and can be used to normalize line endings to Windows mode.
Pattern pattern2 = Patterns.NotAssertBack(CarriageReturn()).Linefeed();

//Same goal can be achieved using ! operator.
Pattern pattern = !Patterns.AssertBack(CarriageReturn()) + Patterns.Linefeed();

//With "using static" statement this pattern is even more concise.
Pattern pattern = !AssertBack(CarriageReturn()) + Linefeed();
```

### Native suffix

There are methods, such as **AnyNative** or **CrawlNative** that behaves depending on the provided **RegexOptions** value.
In these two patterns, a dot can match any character except linefeed or any character in **RegexOptions.Singleline** option is applied.

### using static statement

If you can use new features of the C# 6.0, it is strongly recommended to use following statement:

```c#
using static Pihrtsoft.Text.RegularExpressions.Linq.Patterns;
```

This will allow you to create patterns without repeatedly referencing **Patterns** class.

### NuGet Package
The library is distributed via NuGet: [LinqToRegex](https://www.nuget.org/packages/LinqToRegex).
