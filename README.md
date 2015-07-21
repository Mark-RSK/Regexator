# Regexator
Regexator contains libraries that extends .NET regular expressions.

## LINQ to Regex library
* LINQ to Regex library provides language integrated access to the .NET regular expressions.
* It allows you to create and use regular expressions directly in your code and develop complex expressions while keeping its readability and maintainability.
* Knowledge of the regular expression syntax is not required (but you still should be familiar with basics).
* Escaping of metacharacters that should be interpreted as literals is entirely handled by the library.

### Namespaces
The library contains two namespaces:
```c#
Pihrtsoft.Text.RegularExpressions.Linq;
Pihrtsoft.Text.RegularExpressions.Linq.Extensions;
```
First namespace is a library root namespace. Second namespace contains static classes with extensions methods that extends existing .NET types.

### Pattern Class
The very base library type is the **Pattern** class that represent an immutable regular expression pattern.
Another very important type is the **Patterns** class. This static class returns instances of various kinds of **Pattern** class or its derived types.
When you want to create a pattern you have start with **Patterns** class.
Following pattern will match a digit character. Regex syntax is **\d** .
```c#
var pattern = Patterns.Digit();
```

It is recommended to reference **Patterns** class with **using static** (C# 6.0 or higher) or **Imports** (VB)

```c#
using static Pihrtsoft.Text.RegularExpressions.Linq.Patterns;
```
If you are coding in Visual Basic, use following statement:
```vb
Imports Pihrtsoft.Text.RegularExpressions.Linq.Patterns
```

Previous pattern will then be more concise.
```c#
var pattern = Digit();
```

### CharGrouping Class

**CharGrouping** represents a content of a character group. **CharGrouping** can be created using **CharGroupings** static class that has the same purpose as **Patterns** class.

### Object or Object[]  Parameter
A lot of methods that returns instance of the **Pattern** class accepts parameters of type **Object** that is usually named **content**. This methods can handle following types (typed as **Object**):
* Pattern
* CharGrouping
* String
* Char
* Object[]
* IEnumerable

Last two items in the list, **Object[]** and **IEnumerable** can contains zero or more items (patterns) any one of which has to be matched.

Methods that allows to pass a content typed as **Object** usually allows to pass an array of object with **params** (**ParamArray** in Visual Basic) keyword. This overload simply convert the array of object to the object and calls overload that accept object as an argument. 

### Quantifiers

* ? quantifier matches previous element zero or one times. Use **Maybe** method to apply this quantifier.
* * quantifier matches previous element zero or more times. Use **MaybeMany** method to apply this quantifier.
* + quantifier matches previous element one or more times. Use **OneMany** method to apply this quantifier.

Following pattern will match a white-space character one or more times. Regex syntax is **\s+** .
```c#
var pattern = Patterns.WhiteSpace().OneMany();
```

Previous pattern is wrapped into following one.
```c#
var pattern = Patterns.WhiteSpaces();
```

By default quantifiers are "greedy" which means that previous element is matched as many times as possible. If you want to match previous element as few times as possible, use **Lazy** method.

//Following pattern will match any character zero or more times but as few times as possible. Regex syntax is **[\s\S]*?** .
```c#
var pattern = Patterns.Any().MaybeMany().Lazy();
```

Previous pattern is quite common so it is wrapped into a following method.
```c#
var pattern = Patterns.Crawl();
```

#### Quantifier group

In regular expressions syntax you can apply quantifier only after the element that should be quantified. In LINQ to Regex you can define a quantifier group and put a quantified content into it.

### Operators overloading
#### + Operator
The **+** operator concatenates the operands into a new pattern. Following three pattern have the same meaning.

Pattern class has many instance methods that allows you to concatenate the current instance with another pattern. Following pattern represents empty line.
```c#
var pattern = Patterns.BeginLine().Assert(Patterns.NewLine());
```

Same goal can be achieved using + operator.
```c#
var pattern = Patterns.BeginLine() + Patterns.Assert(Patterns.NewLine());
```

//With "using static" statement pattern more concise.
```c#
//with "using static" statement and + operator
var pattern = BeginLine() + Assert(NewLine());
```

#### - Operator
**-** operator can be used to create character subtraction. This operator is defined for **CharGroup**, **CharGrouping** and **CharPattern** types.

**Except** method is used to create character subtraction. Following pattern matches a white-space character except a carriage return and a linefeed. Regex syntax is **[\s-[\r\n]]** .
```c#
var subtraction = Patterns.WhiteSpace().Except(CharGroupings.CarriageReturn().Linefeed());
```

Same goal can be achieved using **-** operator.
```c#
var subtraction = Patterns.WhiteSpace() - CharGroupings.CarriageReturn().Linefeed();
```

In fact this pattern is quite common so it is wrapped into a following method.
```c#
var subtraction = Patterns.WhiteSpaceExceptNewLine();
```

#### | Operator
**|** Operator combines two patterns into a group in which any of two patterns has to be matched.

**Any** method represents a group in which any one of the specified patterns has to be matched.
```c#
Pattern pattern = Pattern.Any("first", "second", "third");
```

Same goal can be achieved using | operator
```c#
Pattern pattern = Pattern.Group("first" | "second" | "third);
```

#### ! Operator

**!** operator is used to create pattern that has opposite meaning than operand.

This pattern represents a linefeed that is not preceded with a carriage return and can be used to normalize line endings to Windows mode.
```c#
var pattern2 = Patterns.NotAssertBack(CarriageReturn()).Linefeed();
```

Same goal can be achieved using ! operator.
```c#
var pattern = !Patterns.AssertBack(CarriageReturn()) + Patterns.Linefeed();
```

With "using static" statement the pattern is more concise.
```c#
var pattern = !AssertBack(CarriageReturn()) + Linefeed();
```

### Native suffix

There are methods, such as **AnyNative** or **CrawlNative** that behaves differently depending on the provided **RegexOptions** value.
In these two patterns, a dot can match any character except linefeed or any character in **RegexOptions.Singleline** option is applied.

This will allow you to create patterns without repeatedly referencing **Patterns** class.

### NuGet Package
The library is distributed via NuGet: [LinqToRegex](https://www.nuget.org/packages/LinqToRegex).
