C# and F# library (.NET)
=========================

|

**Summary:** This is a C# and F# library for **Representation Theory**, **abstract structures** and their **formal models** implemented using the .NET Core framework.

|

.. contents:: **Table of Contents**

|

About
---------------------------------

This library demonstrates computational *definitions* (i.e. models) and *compositions* of various **categories** using both C# and F# within a single .NET solution, including *interoperability* between the two languages. It aims to provide a solid foundation for representing, experimenting with, and extending **category-theoretic structures** and **system-theoretic constructions** (e.g., *universal construction*, *ambient construction*, *hierarchical architectures*) for modelling (i.e. synthesizing or designing) categories, morphisms and (categorical) objects within a .NET environment.

Standard Engineering principles from System Theory, such as **composition and decomposition** or **analysis and synthesis**, are employed in the context of defining *abstract structures* that reside in *multiple hiearchical layers*. As a result, *ontological transformations* (e.g., morphisms, functors, and natural transformations) are treated abstractly in a **unifying way**. The goal is not merely to implement abstract definitions, but also to provide concrete examples, tools, and reusable components that can serve *educational* and *research purposes* alike.

The library was implemented in **C#** and **F#** using the `.NET Core 6.0.428 <https://dotnet.microsoft.com/en-us/download/dotnet/6.0>`_ framework. Given backward compatibility by the .NET maintainers, the library should work with *any later version* of .NET Core, so there is *no need to downgrade* its version if you have already installed a later version.


Folder structure
---------------------------------

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
---------------------------------

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

**Purpose:** Provide examples implemented using (a) *purely* C# code (optionally calling F#), (b) *purely* F# code (optionally calling C#), and (c) a mix-and-match of C# and F# code jointly implemented. Also, provide *quick scripts* (i.e. stand-alone files) for lightweight experimentation without the need to create any projects.

The ``examples/`` folder contains examples implemented using C# and F# code organized in subfolders by language and usage. The table below outlines the purpose of each folder, and how it interacts with the C# and F# libraries.

Stand-alone scripts are recommended for begineers in the Object-Oriented Programming (OOP) paradigm.

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

Roadmap and functionalities
---------------------------------

C# library
^^^^^^^^^^^^^^^^^^^^^^^^^

Below is an outline of *currently implemented* and *planned* **category-theoretic structures**, along with their corresponding **system-theoretic constructions**:

- **General definitions**
    - ☑ Definition of a category (as an Interface)
    - ☑ Three axioms: existence of morphisms, identity, and composition (i.e. associativity and unitality)
- **Single-object category**
    - ☐ Monoid as a category
- **Free categories**
    - ☑ Definition of a free category (as an Abstract Class)
    - ☑ Construction of directed multigraphs (i.e. quivers)
    - ☑ Path composition and simplification (i.e. reduction)
- **Non-free categories**
    - ☐ Reduction of the multigraph with algebraic equivalences imposed
- **Types of morphisms**
    - ☐ Monomorphisms and special cases (e.g., sections)
    - ☐ Epimorphisms and special cases (e.g., retractions)
    - ☐ Bimorphisms
    - ☐ Isomorphisms
- **Functors and cofunctors**
    - ☐ Definition of a functor using an indexed category
    - ☐ Detection of commutativity in a configuration (i.e. diagrammatic setup) of a category
    - ☐ Fibrations and opfibrations
    - ☐ Covariant functor
    - ☐ Contravariant functor (i.e. cofunctor)
    - ☐ Hom-functor
    - ☐ Representative functor
    - ☐ Presheaves and sheaves
    - ☐ Profunctor
    - ☐ Bifunctor and co-bifunctor
- **Natural transformations**
    - ☐ Definition of a natural transformations
    - ☐ Functor category
    - ☐ 2-category
    - ☐ Bicategory (i.e. weak 2-category) 
- **Monad and comonads**
    - ☐ Monads and comonads
    - ☐ Monoidal categories (i.e. monoids as objects)
    - ☐ Kleisli and co-Kleisli (Eilenberg-Moore) categories
    - ☐ Categories of algebras and coalgebras
- **Higher Category Theory**
    - ☐ n-categories
    - ☐ ∞-groupoids
    - ☐ ∞-categories
    - ☐ (∞, n)-categories
    - ☐ Higher order categories (i.e. ∞-groupoids as objects)
    - ☐ ∞-cosmoi (i.e. ∞-categories as objects)
- **Universal constructions**
    - ☐ General definition of limits and colimits
    - ☐ Products and coproducts
    - ☐ Pullbacks and pushouts
    - ☐ Initial and terminal objects
    - ☐ Equalizers and coequalizers
    - ☐ Algebras (i.e. F-algebras) and coalgebras
    - ☐ Ends and coends
    - ☐ Free and cofree objects
    - ☐ Free and cofree monoids
    - ☐ General definition of adjunctions (i.e. left and right adjoint functors)
    - ☐ Left and right Kan extensions
    - ☐ General definition of exponentiation (i.e. images and coimages)
- **Ambient constructions**
    - ☐ Topos
    - ☐ Enriched category
    - ☐ Embedding of a category
    - ☐ Yoneda and co-Yoneda
- **Hierarchical architectures**
    - ☐ Multi-layer architectures

|br|

Below is an outline of *currently implemented* and *planned* **functionalities** (such as helper classes and utils):

- **ArgParser**
    - ☑ Definition of a very minimal ArgParser class to parse flags inside ``.csx`` scripts

F# library
^^^^^^^^^^^^^^^^^^^^^^^^^

- TBD

Examples
^^^^^^^^^^^^^^^^^^^^^^^^^

- **Examples using .csx stand-alone scripts:**
    - ☑ Examples of various configurations in a free category
    - ☐ Examples of various configurations in a non-free category
- **Examples using .fsx stand-alone scripts:**
    - TBD


.. |br| raw:: html

  <br/>
