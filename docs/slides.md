# Lesser-known .NET Features and Libraries

Ravindran Keshavan

Senior Architect

19\-April\-2025

# About Me

## Ravindran Keshavan

[https://github\.com/ravindrank](https://github.com/ravindrank)

- I’m an Architect working in areas of Product development\, Platform Engineering\, Cloud Modernization

- \.NET\, Angular\, Azure\, SQL Server\, Azure\, MS SQL Server\, Cosmos

* [More on LinkedIn](https://www.linkedin.com/in/ravindrank/)

# Agenda

# Init-Only Properties

**Key Benefits**

**What are Init\-Only Properties?**

Introduced in **C\# 9** \.

Allow properties to be set **only during object initialization** \.

Once the object is initialized\, the value of an init\-only property cannot be changed

Immutability: Helps create objects with properties that should not be modified after creation\, enhancing code reliability and preventing unintended state changes\.

Clear Intent: Explicitly signals that a property's value is meant to be set only during object construction\.

Support for Object Initializers: Enables a clean and readable syntax for setting property values upon object creation\.

Usage with Records: In record classes\, primary constructor parameters are synthesized as public init\-only properties\. In readonly record structs\, they are readonly\.

# Init-Only Properties - Demo

![](img\LesserKnownNETv21_0.png)

# Span & Memory

Key Benefits

Introduction

Span\<T> and Memory\<T> are modern C\# features for high\-performance memory manipulation\.

They provide type\-safe and memory\-safe ways to work with contiguous regions of memory\.

Their primary goal is to avoid unnecessary memory allocations and copying\, leading to improved performance and reduced garbage collection overhead

Performance: Enable writing low\-allocation code\, crucial in performance\-critical scenarios\. Benchmarking shows Span\<T>\.Slice\(\) can be significantly faster than string\.Substring\(\) with no allocations\.

Efficiency: Allow working with slices of arrays\, strings\, and unmanaged memory without creating new copies\.

Type Safety: Ensure memory access within bounds and prevent common pointer\-related bugs\.

Versatility: Can represent memory residing on the stack \(stackalloc\)\, managed heap\, or unmanaged memory\.

Integration: Seamlessly work with arrays\, subarrays\, strings\, substrings\, and native buffers\. C\# 14 introduced first\-class language support for Span\<T> and ReadOnlySpan\<T>

# Span vs. Memory

Memory

Span

A ref struct\, residing only on the stack\.

Has stack\-only restrictions: cannot be boxed\, cannot be fields of non\-ref structs/classes\, cannot be used in generic type parameters\, cannot cross await or yield boundaries\.

Provides direct\, low\-level access to contiguous memory\.

Offers read\-write access to the memory

A struct\, can reside on the managed heap\.

No stack\-only restrictions\, making it more versatile for various scenarios\, including asynchronous operations and storing in collections\.

Provides a Span\<T> property to get efficient access to the underlying memory when needed\.

A more general\-purpose type for representing contiguous memory

# Span - Demo

![](img\LesserKnownNETv21_1.png)

![](img\LesserKnownNETv21_2.png)

---

Span<T> and Memory<T> are powerful tools in modern C# for writing efficient and safe code when dealing with memory. Choose Span<T> for short-lived, stack-based operations requiring high performance, and Memory<T> for more general-purpose memory handling that might involve heap allocation or asynchronous operations

# Memory - Demo

![](img\LesserKnownNETv21_3.png)

# Interoperability with Platform Invoke (PInvoke)

How does it work?

What is Platform Invoke \(PInvoke\)?

Platform Invoke \(PInvoke\) is a service that enables managed code \(code running under the \.NET Common Language Runtime \- CLR\) to call unmanaged functions implemented in dynamic link libraries \(DLLs\)\.

This allows \.NET developers to leverage existing investments in unmanaged code such as the Microsoft Windows API

PInvoke locates and invokes an exported function in a DLL\.

It handles the marshaling of arguments \(such as integers\, strings\, arrays\, and structures\) across the boundary between managed and unmanaged code as needed\.

The System\.Runtime\.InteropServices namespace provides the necessary tools for this interoperability\.

You typically use the DllImportAttribute to specify the DLL containing the unmanaged function and the entry poin

# PInvoke - Demo

![](img\LesserKnownNETv21_4.png)

---

Key Benefits:
•Leverage Existing Code: Allows you to utilize existing unmanaged libraries and functionalities within your .NET applications1 .
•Access Platform-Specific Features: Enables access to operating system-specific APIs, such as the Windows API1 ....

Important Considerations:
•Security Risks: Calling unmanaged code bypasses the CLR's security mechanisms, potentially introducing security vulnerabilities3 . Exercise caution when interacting with unmanaged code.
•Marshaling Complexity: Marshaling data between managed and unmanaged types can be complex and requires careful attention to data types and memory management2 ....
•Platform Dependence: PInvoke is inherently platform-dependent as it relies on specific DLLs available on the target operating system.

# Embracing Flexibility with the dynamic keyword in C#

Key Use Cases

What is the dynamic Keyword?

The dynamic keyword in C\# bypasses static type checking at compile time\.

Instead\, operations on dynamic objects are resolved at runtime\.

In many cases\, an object declared as dynamic functions like it has type object\.

Interoperability with COM Objects: The dynamic type simplifies working with COM components by treating object types in COM signatures as dynamic\, reducing the need for explicit casting\. This is particularly useful when using EmbedInteropTypes\.

Interoperability with Dynamic Languages: The dynamic keyword is crucial for interacting with dynamic programming languages like IronPython\, which are supported by the Dynamic Language Runtime \(DLR\)\.

Working with Late\-Bound Objects: You can use dynamic to interact with structures that don't conform to static types known at compile time\, such as the HTML Document Object Model \(DOM\)\.

Reflection: While not explicitly stated as a primary use case in the excerpts\, dynamic can sometimes simplify interactions when using reflection\, although System\.Reflection\.Emit and Expression Trees offer more direct control for dynamic code generation\.

---

Working with dynamic:
•You can declare variables as dynamic:
•Operations on dynamic objects are not checked by the compiler2 . Errors will surface at runtime if an operation is invalid7 .
•The result of most dynamic operations is also dynamic
Creating Custom Dynamic Objects:
•You can create your own dynamic objects using classes in the System.Dynamic namespace
•ExpandoObject: Allows you to specify the members of an object at runtime
•Inheriting from DynamicObject: Enables you to override members to provide custom dynamic behavior at runtime. For example, you can dynamically expose the contents of a text file as properties11 ....

# dynamic (contd.)

Important Considerations

Benefits

Increased Flexibility: Enables programs to interact with various types and structures without rigid compile\-time type definitions\.

Simplified Interoperability: Makes working with COM objects and dynamic languages more straightforward by reducing the need for explicit casting

Runtime Errors: The lack of compile\-time type checking means errors related to incorrect operations or missing members will only be caught at runtime\.

Potential Performance Overhead: Dynamic dispatch \(resolving operations at runtime\) can sometimes introduce a performance overhead compared to statically typed code\.

Reduced IntelliSense: You may experience less comprehensive IntelliSense support when working with dynamic objects as the compiler has limited type information\.

---

The dynamic keyword offers significant flexibility and simplifies interoperability in specific scenarios, but it's crucial to be aware of the potential for runtime errors and performance implications. Use it judiciously when dealing with inherently dynamic systems or when the benefits of late binding outweigh the risks.

# dynamic - Demo

![](img\LesserKnownNETv21_5.png)

![](img\LesserKnownNETv21_6.png)

# Dynamic Code Generation

System\.Reflection\.Emit \(e\.g\.\, DynamicMethod\)

What is Dynamic Code Generation?

- Dynamic code generation refers to the ability of a program to create and execute code at runtime\.
- This allows for greater flexibility and adaptability compared to code that is fixed at compile time\.
- Techniques
  - System\.Reflection\.Emit
  - Expression Trees
  - Dynamic keyworkd

Allows you to build and execute methods on the fly using Intermediate Language \(IL\) instructions\.

Useful for scenarios like creating high\-performance stubs\, interceptors\, or dynamic proxies\.

Example from the sources: Creating a simple "Hello\, World\!" method at runtime

# Dynamic Code Generation (contd.)

dynamic Keyword and Dynamic Language Runtime \(DLR\)

Expression Trees

Represent code as a data structure \(tree\)\.

Allow you to examine\, modify\, and execute code at runtime\.

Enable scenarios like dynamic LINQ queries\, creating domain\-specific languages\, and interoperability with dynamic languages\.

The C\# compiler can create expression trees from lambda expressions\. You can also build them manually using the System\.Linq\.Expressions namespace\.

Expression trees can be compiled into executable delegates\.

The dynamic keyword bypasses static type checking at compile time\, allowing operations to be resolved at runtime\.

The DLR provides the infrastructure for supporting the dynamic type and dynamic programming languages like IronPython\.

Useful for interoperability with COM objects\, dynamic languages\, and working with structures that don't match a static type \(e\.g\.\, HTML DOM\)\.

You can create custom dynamic objects using classes in the System\.Dynamic namespace\, like ExpandoObject or by inheriting from DynamicObject

**Considerations**

**Benefits of Dynamic Code Generation**

Flexibility and Adaptability: Programs can adjust their behavior based on runtime conditions\.

Performance Optimization: Can generate specialized code tailored to specific needs at runtime\.

Extensibility: Enables plugin architectures and dynamic loading of code\.

Interoperability: Facilitates communication with dynamic languages and COM components\.

Metaprogramming: Allows writing code that manipulates other code\.

Complexity: Dynamic code generation can make code harder to understand and debug\.

Performance Overhead: Generating and executing code at runtime can have a performance cost compared to statically compiled code\.

Security Risks: Dynamically generated code should be carefully validated to prevent potential security vulnerabilities\.

---

Dynamic code generation is a powerful feature in .NET that enables advanced programming scenarios when used judiciously

# Dynamic Code Generation - Demo

![](img\LesserKnownNETv21_7.png)

![](img\LesserKnownNETv21_8.png)

# Diving Deep into Expression Trees

Why Use Expression Trees?

What are Expression Trees?

Expression trees are data structures that represent code\. They are built upon the same structures that compilers use to analyze code\.

Each node in an expression tree represents an expression\, such as a method call or a binary operation \(e\.g\.\, x < y\)\.

Think of them as an in\-memory\, tree\-like representation of code\. For example\, var sum = 1 \+ 2; can be represented as a tree with nodes for variable declaration\, assignment\, addition\, and the constants 1 and 2

Examine Code Structure: They allow you to inspect the structure and content of code at runtime\. You can see values\, method and property names\, and constant expressions\.

Modify Code at Runtime: Expression trees are immutable\, so to change them\, you create a new tree by copying and replacing nodes\. This enables dynamic algorithm modification\.

Execute Code Dynamically: Expression trees representing lambda expressions can be compiled into executable delegates and invoked\.

Translate Code: They facilitate the translation of code into other environments or formats \(e\.g\.\, LINQ to SQL\)

# Expression Trees (contd.)

Key Use Cases

Creating Expression Trees

Compiler Generation: When a lambda expression is assigned to a variable of type Expression<TDelegate>\, the C\# compiler automatically emits code to build an expression tree\.

Manual Construction: You can also build expression trees manually using the classes in the System\.Linq\.Expressions namespace\. This involves creating individual nodes \(e\.g\.\, ParameterExpression\, ConstantExpression\, BinaryExpression\) and connecting them to form the tree

Language\-Integrated Query \(LINQ\): Many LINQ providers \(like Entity Framework\) accept expression trees as arguments\, allowing them to translate C\# queries into database\-specific query languages like SQL\.

Dynamic Languages \(DLR\): Expression trees are used in the Dynamic Language Runtime to provide interoperability between dynamic languages and \.NET\.

Metaprogramming: They enable you to write code that manipulates other code\, such as creating dynamic proxies or interceptors\.

Dynamic LINQ: Libraries like Dynamic LINQ allow you to build LINQ queries using strings that are then parsed into expression trees at runtime

---

Limitations:
•Expression trees cannot contain all C# language elements .... For instance, await expressions, async lambda expressions, statements (like loops and if/else), and certain newer C# features don't translate well
•Loops are typically created using a single loop expression with break and continue expressions.
•You cannot recursively call the same expression within its expression tree form

Examining and Debugging Expression Trees:
•You can use the DebugView property (available in debug mode) to get a string representation of the expression tree structure23 ....
•Visual Studio offers Expression Tree Visualizers that provide a tree view of the nodes and their properties24 .... You can access these from DataTips, Watch windows, Autos windows, or Locals windows during debugging24 .
•Tools like RoslynQuoter can show the syntax factory API calls used to construct a program's syntax tree

Expression trees provide a powerful mechanism for interacting with code as data, enabling advanced scenarios in data access, dynamic programming, and code analysis

# Expression Trees - Demo

![](img\LesserKnownNETv21_9.png)

![](img\LesserKnownNETv21_10.png)

# Managing Asynchronous Operations with Cancellation Tokens

How Cancellation Works

What are Cancellation Tokens?

Cancellation Tokens in \.NET provide a cooperative mechanism to signal that an asynchronous operation should be cancelled\.

They involve two key components:

CancellationTokenSource: Represents the object that issues the cancellation request\. It has a Token property that provides the associated CancellationToken\. You can call the Cancel\(\) method on a CancellationTokenSource to signal cancellation\. The CancelAfter\(Int32\) method can be used to schedule a cancellation after a specified time\.

CancellationToken: Represents the token that is passed to asynchronous operations\. The operation can periodically check the IsCancellationRequested property to determine if cancellation has been requested

A CancellationTokenSource is created\.

The CancellationToken obtained from the CancellationTokenSource\.Token property is passed as a parameter to the asynchronous method\.

The asynchronous operation monitors the IsCancellationRequested property of the CancellationToken\.

When cancellation is requested by calling CancellationTokenSource\.Cancel\(\)\, IsCancellationRequested becomes true\.

The asynchronous operation should then gracefully stop its execution and can throw an OperationCanceledException\.

Calling code can use a try\-catch block to handle the OperationCanceledException

# Cancellation tokens - Demo

![](img\LesserKnownNETv21_11.png)

![](img\LesserKnownNETv21_12.png)

# Enhancing Resilience with the Polly Library

Key Policies Supported by Polly

What is Polly?

Polly is a powerful \.NET resilience and transient\-fault\-handling library\.

It provides a fluent API to define and apply policies to your \.NET applications\, making them more robust and fault\-tolerant\.

Polly helps your applications handle common issues in distributed systems and unreliable networks gracefully

Retry: Automatically retry operations that fail due to transient faults\, such as network glitches or temporary service unavailability\. You can specify the number of retry attempts and a delegate to be called after each attempt\.

Circuit Breaker: Prevents your application from repeatedly attempting to execute a failing operation\, giving the failing service time to recover and avoiding cascading failures\.

Timeout: Ensures that an operation does not exceed a specified duration\, preventing indefinite blocking\.

And More: Polly supports other policies like Bulkhead Isolation\, Cache\, Fallback\, and Rate Limiter \(though not explicitly detailed in the provided excerpts\)\.

---

Polly is an essential library for building resilient and robust .NET applications by gracefully handling transient faults

Benefits of Using Polly:
•Improved Application Stability: Makes your applications more resilient to transient errors3 ....
•Enhanced User Experience: By handling faults and retrying operations, Polly can improve the perceived reliability of your application for users5 .
•Simplified Fault Handling: Provides an easy and expressive way to implement complex fault-handling logic without writing repetitive boilerplate code1 .
•Customizable Policies: Polly's policies are highly customizable to fit the specific needs of your application3

# Polly (contd.)

Demo

Benefits

Improved Application Stability: Makes your applications more resilient to transient errors\.

Enhanced User Experience: By handling faults and retrying operations\, Polly can improve the perceived reliability of your application for users\.

Simplified Fault Handling: Provides an easy and expressive way to implement complex fault\-handling logic without writing repetitive boilerplate code \.

Customizable Policies: Polly's policies are highly customizable to fit the specific needs of your application\.

![](img\LesserKnownNETv21_13.png)

---

Simple Retry Policy Example:

using Polly;
using System;
using System.Net.Http;

var retryPolicy = Policy
.Handle<HttpRequestException>() // Specify the exception type to handle
.Retry(3, (exception, retryCount) => // Configure retry attempts and a callback
{
Console.WriteLine($"Retry attempt {retryCount}");
});

var client = new HttpClient();
retryPolicy.Execute(() => // Execute the code protected by the policy
{
var response = client.GetAsync("https://www.example.com").Result;

if (!response.IsSuccessStatusCode)
{
throw new HttpRequestException();
}

});

In this example, if an HttpRequestException occurs, Polly will retry the web request up to 3 times, logging each retry attempt

Learn More: Visit thepollyproject.org

Polly is an essential library for building resilient and robust .NET applications by gracefully handling transient faults

# Simplify Assembly Weaving with Fody

Key Concepts

What is Fody?

Fody is an extensible tool for weaving \.NET assemblies\.

It allows you to add code to your assemblies at compile time without manually modifying the Intermediate Language \(IL\)\.

One of the ways to automate repetitive coding tasks by injecting code during the build process\.

Weavers: Fody works through add\-ins called Weavers\. These weavers are NuGet packages that perform specific code injection tasks\.

Convention over Configuration: Many weavers operate based on conventions\, reducing the amount of explicit configuration needed\.

IL Manipulation: Under the hood\, Fody and its weavers directly manipulate the IL of your compiled assemblies\.

# Fody (contd.)

Common Examples

Benefits of Using Fody

Reduces Boilerplate Code: Automate tasks like implementing INotifyPropertyChanged\, logging\, or aspect\-oriented programming \(AOP\) patterns\.

Improves Code Readability: By removing repetitive code\, your core business logic becomes clearer\.

Encapsulates Cross\-Cutting Concerns: Weave in functionalities like logging or validation consistently across your codebase\.

Extensibility: The weaver architecture allows for a wide range of functionalities and the creation of custom weavers\.

PropertyChanged\.Fody: Automatically implements INotifyPropertyChanged\.

Log4Net\.Fody/NLog\.Fody/Serilog\.Fody: Simplifies logging integration\.

Costura\.Fody: Embeds dependencies into your main assembly\.

---

Important Considerations:
•Build-Time Dependency: Fody operates during the build process.
•Potential Complexity: Understanding how weavers manipulate IL can be necessary for advanced scenarios or debugging.
•Integration: Ensure weavers are compatible with your target framework.

Fody offers a powerful way to streamline your .NET development by automating code weaving tasks, leading to cleaner and more maintainable code. You can explore available weavers and learn more about its capabilities on its GitHub repository (information not in sources, may require independent verification).

# Fody - Demo

![](img\LesserKnownNETv21_14.png)

![](img\LesserKnownNETv21_15.png)

# Humanizer

Key Features & Benefits

What is Humanizer?

Humanizer is a \.NET library designed to make data more readable for humans\.

It helps you humanize\, transform\, and format data in a user\-friendly way\.

The library offers a simple\, intuitive\, and consistent API to convert raw data into an easily understandable format

Number to Words: Easily convert numerical values into their word equivalents \(e\.g\.\, 123 becomes "one hundred and twenty\-three"\)\.

Readable Dates and Times: Format dates and times in a manner that is natural for users to comprehend \(e\.g\.\, displaying "yesterday" or "in 5 minutes"\)\.

User\-Friendly String Manipulation: Manipulate strings to make them more meaningful for users\.

Pluralization and Singularization: Automatically handle the plural and singular forms of words\, ensuring grammatically correct output\.

Enum Humanization: Convert C\# enum values into human\-readable strings\.

Time Span Humanization: Present time spans in an understandable format \(e\.g\.\, "one day" instead of "24:00:00"\)\.

Improved User Experience: By presenting data in a human\-readable format\, you can enhance the user experience and add professionalism to your applications

---

Example:
var daysBetween = (DateTime.Now - DateTime.Now.AddDays(-97)).TotalDays;
var humanizedDays = daysBetween.ToWords();
Console.WriteLine(humanizedDays); // Output: ninety-seven

This simple code snippet demonstrates how Humanizer can transform a numerical representation of days into a more easily understandable phrase
Why Use Humanizer?
•Makes data intended for machines understandable and engaging for humans
•Reduces the complexity of presenting information to end-users
•Automates tasks related to data formatting and text manipulation

Get Started: Explore the Humanizer library further on its GitHub repository https://github.com/Humanizr/Humanizer

It's a powerful yet "lesser-known" gem that can significantly improve the usability of your .NET applications

# Humanizer - Demo

![](img\LesserKnownNETv21_16.png)

![](img\LesserKnownNETv21_17.png)

# Efficient Serialization with MessagePack

Key Benefits

What is MessagePack?

MessagePack is a fast and efficient binary serialization format\.

It's designed to be more compact and faster than other formats like JSON for serializing data\.

The library provides an easy way to serialize and deserialize \.NET objects into this format

Performance: MessagePack is known for its speed in both serialization and deserialization processes\.

Compactness: The binary format typically results in smaller serialized data sizes compared to text\-based formats\, saving bandwidth and storage\.

It is considered a valuable library for its functionality and ease of use

---

MessagePack offers a straightforward API for serializing and deserializing objects in .NET.

Learn More:
•Visit the official MessagePack-CSharp GitHub repository for detailed information and usage examples: https://github.com/MessagePack-CSharp/MessagePack-CSharp2
•Further insights can be found in the linked article: https://neuecc.medium.com/messagepack-for-c-v2-new-era-of-net-core-unity-i-o-pipelines-6950643c10532
(Note: This link is provided in the source, not the content of the source itself).

In summary, MessagePack is a powerful library for .NET developers seeking high-performance and compact binary serialization

# Message Pack - Demo

![](img\LesserKnownNETv21_18.png)

![](img\LesserKnownNETv21_19.png)

![](img\LesserKnownNETv21_20.png)

![](img\LesserKnownNETv21_21.png)

# Measure Performance Easily with BenchmarkDotNet

Key Benefits

What is BenchmarkDotNet?

BenchmarkDotNet is a powerful \.NET library for benchmarking\.

It helps you measure the performance of your \.NET code with ease\.

You can use it to compare the speed and memory usage of different code snippets

Easy to Use: Provides a straightforward way to define and run benchmarks\.

Performance Insights: Helps you understand the performance characteristics of your code\, including execution time\.

Memory Analysis: Can track memory allocations and garbage collection during benchmarking\.

Comparison: Allows you to easily compare the performance of different implementations or methods\.

Regression Detection: Useful for identifying performance regressions during development

---

Simple Usage Example:
1.Install the NuGet package: Install-Package BenchmarkDotNet
2.Create a class with benchmark methods:
3.Run the benchmarks: Build your project in Release mode and execute the application. BenchmarkDotNet will automatically run the benchmarks and display the results.

Example Result Insights:
BenchmarkDotNet will show metrics like:
•Mean: Average execution time.
•Gen0: Number of Gen 0 Garbage Collections.
•Allocated: Amount of memory allocated.

Learn More:
•Explore the BenchmarkDotNet library on its GitHub repository1 .
•Refer to articles and documentation on using BenchmarkDotNet for detailed usage and advanced features.

BenchmarkDotNet is an essential tool for any .NET developer looking to understand and optimize the performance of their applications.

# BenchmarkDotNet - Demo

![](img\LesserKnownNETv21_22.png)

# Run Language Models in .NET with OllamaSharp

Key Features & Benefits

What is OllamaSharp?

<span style="color:#242424">OllamaSharp</span> is a C\#/\.NET binding for the [Ollama](https://github.com/jmorganca/ollama/blob/main/docs/api.md)[ API](https://github.com/jmorganca/ollama/blob/main/docs/api.md)\, simplifying interactions with Ollama both locally and remotely\. It allows \.NET developers to run large language models \(LLMs\) like LLaMA and GPT directly within their C\# applications\.

You can leverage the power of these models without needing to compile llama\.cpp separately

\.NET Integration: Provides a seamless way to incorporate powerful language models into \.NET projects using C\#\.

Ease of use: Interact with Ollama in just a few lines of code\.

Reliability: Powering [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel/pull/7362)\, [\.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/community-toolkit/ollama) and [Microsoft\.Extensions\.AI](https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/)

API coverage: Covers every single Ollama API endpoint\, including chats\, embeddings\, listing models\, pulling and creating new models\, and more\.

Real\-time streaming: Stream responses directly to your application\.

Progress reporting: Real\-time progress feedback on tasks like model pulling\.

Tools engine: [Sophisticated tool support with source generators](https://awaescher.github.io/OllamaSharp/docs/tool-support.html)\.

Multi modality: Support for [vision models](https://ollama.com/blog/vision-models)\.

---

Example Use Cases (Inferred):
•Building applications with natural language understanding capabilities.
•Implementing local AI assistants or chatbots.
•Performing text generation and analysis directly within .NET applications.
Get Started:
•Explore the LLamaSharp library to integrate state-of-the-art language models into your .NET projects.

In summary, LLamaSharp brings the capabilities of large language models to the .NET platform in an accessible and efficient manner.

# OllamaSharp - Demo

![](img\LesserKnownNETv21_23.png)

![](img\LesserKnownNETv21_24.png)

# DotNetFiddle.net

Online compiler for C\#\, F\#

Simple and easy to use

Support multiple \.NET Versions and project types

You can also install Nuget Packages

Share publicly or with link

# Sharplab.io

Online tool to decompile \.NET into IL\, JIT

Run \.NET code

# Conclusion

We have just seen some features and libraries today\.

Checkout \.NET Documentation [https://learn\.microsoft\.com/en\-us/dotnet/](https://learn.microsoft.com/en-us/dotnet/)

All the Demo code is on my GitHub Public repo [https://github\.com/ravindrank/LesserKnown\.NET](https://github.com/ravindrank/LesserKnown.NET)

# Things to try/checkout

How to use platform invoke to play a WAV file [https://learn\.microsoft\.com/en\-us/dotnet/csharp/advanced\-topics/interop/how\-to\-use\-platform\-invoke\-to\-play\-a\-wave\-file](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/how-to-use-platform-invoke-to-play-a-wave-file)

Read more on Span & Memory [https://learn\.microsoft\.com/en\-us/archive/msdn\-magazine/2018/january/csharp\-all\-about\-span\-exploring\-a\-new\-net\-mainstay](https://learn.microsoft.com/en-us/archive/msdn-magazine/2018/january/csharp-all-about-span-exploring-a-new-net-mainstay)

A Complete \.NET Developer's Guide to Span with Stephen Toub [https://learn\.microsoft\.com/en\-us/shows/on\-dotnet/a\-complete\-dotnet\-developers\-guide\-to\-span\-with\-stephen\-toub](https://learn.microsoft.com/en-us/shows/on-dotnet/a-complete-dotnet-developers-guide-to-span-with-stephen-toub)

Dynamic Run – Create and Run \.NET code dynamically By Laurent Kempe [https://github\.com/laurentkempe/DynamicRun](https://github.com/laurentkempe/DynamicRun)
