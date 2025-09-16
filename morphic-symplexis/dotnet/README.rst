C# and F# library (.NET)
=========================

|

**Summary:** This is a C# and F# library for **Category Theory** implemented using the .NET Core framework.

|

.. contents:: **Table of Contents**

|

About
-------------------------

This library was implemented in **C#** and **F#** using the `.NET Core 6.0.428 <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>`_ framework. Given backward compatibility by the .NET maintainers, the library should work with any later version of .NET Core, so there is no need to downgrade its version if you have already installed a later version.

Folder structure
-------------------------

The following **folder structure** is used:

.. code-block:: text

  dotnet/
  └── MorphicSymplexis/
      ├── examples/
      │   ├── Examples.CSharp/        # .cs files, optionally calling F#
      │   ├── Examples.FSharp/        # .fs files, optionally calling C#
      │   ├── Examples.Mixed/         # .cs and .fs files
      │   └──scripts/
      │       ├── csharp/             # .csx files
      │       ├── fsharp/             # .fsx files
      │       └── shared/             # .json files and other file types
      ├── MorphicSymplexis.CSharp/
      │   └── MorphicSymplexis.CSharp.csproj
      ├── MorphicSymplexis.FSharp/
      │   └── MorphicSymplexis.FSharp.fsproj
      └── MorphicSymplexis.sln

Folder roles
-------------------------

Following the good practice of *separation of concerns*, each folder serves a different role, as explained below.

Library folders
^^^^^^^^^^^^^^^^^^^^^^^^^

**Purpose:** Implement the .NET library using C# and F# *separately* via two distinct project folders.

Example folders
^^^^^^^^^^^^^^^^^^^^^^^^^

**Purpose:** Provide examples implemented using (a) *purely* C# code (optionally calling F#), (b) *purely* F# code (optionally calling C#), and (c) a mix-and-match of C# and F# code jointly implemented. Also, provide quick scripts without creating projects for lightweight experimentation.

.. |br| raw:: html

  <br/>
