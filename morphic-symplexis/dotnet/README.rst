C# and F# library (.NET)
=========================

|

**Summary:** This is a C# and F# library for **Category Theory** implemented using the .NET Core framework.

|

.. contents:: **Table of Contents**

|

About
-------------------------

This library demonstrates computational *definitions* (i.e. models) and *compositions* of various **categories** using both C# and F# within a single .NET solution, including *interoperability* between the two languages.

The library was implemented in **C#** and **F#** using the `.NET Core 6.0.428 <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>`_ framework. Given backward compatibility by the .NET maintainers, the library should work with *any later version* of .NET Core, so there is *no need to downgrade* its version if you have already installed a later version.


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

The main **library folders** used in the .NET implementation of ``morphic-symplexis`` are:

- ``MorphicSymplexis.CSharp/`` – C# project folder
- ``MorphicSymplexis.FSharp/`` – F# project folder

The C# project folder does not contain any F# code implementation, and similarly, the F# project folder does not contain any C# code implementation. However, each project folder *optionally* calls APIs implemented in other languages.

Example folders
^^^^^^^^^^^^^^^^^^^^^^^^^

**Purpose:** Provide examples implemented using (a) *purely* C# code (optionally calling F#), (b) *purely* F# code (optionally calling C#), and (c) a mix-and-match of C# and F# code jointly implemented. Also, provide *quick scripts* (i.e. standalone files) for lightweight experimentation without the need to create any projects.

The ``examples/`` folder contains examples implemented using C# and F# code organized in subfolders by language and usage. The table below outlines the purpose of each folder, and how it interacts with the C# and F# libraries.

|br|

+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| Folder Name                | Contains .cs   | Contains .fs   | Calls C# library    | Calls F# library    | Purpose                                           |
+============================+================+================+=====================+=====================+===================================================+
| ``Examples.CSharp/``       | ✔              |                | ✔                   | Optional            | Pure C# examples. May optionally call F# code.    |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| ``Examples.FSharp/``       |                | ✔              | Optional            | ✔                   | Pure F# examples. May optionally call C# code.    |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| ``Examples.Mixed/``        | ✔              | ✔              | ✔                   | ✔                   | Mixed-language examples demonstrating interop.    |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| ``scripts/csharp/``        | ✔   (.csx)     |                | ✔                   |                     | C# scripts using `.csx` files.                    |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| ``scripts/fsharp/``        |                | ✔   (.fsx)     |                     | ✔                   | F# scripts using `.fsx` files.                    |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+
| ``scripts/shared/``        |                |                |                     |                     | Shared files (e.g., JSON, configs, inputs).       |
+----------------------------+----------------+----------------+---------------------+---------------------+---------------------------------------------------+

Legend:
  "✔" = direct usage   |br|
  "Optional" = indirect or optional use   |br|
  ``.csx`` and ``.fsx`` are C# and F# single script files, respectively


.. |br| raw:: html

  <br/>
