import Mathlib.CategoryTheory.Category.Basic



/-

Category defined as typeclass:

universe u v

class Category (Obj : Type u) where
  Hom      : Obj → Obj → Type v
  id       : {X : Obj} → Hom X X
  comp     : {X Y Z : Obj} → Hom X Y → Hom Y Z → Hom X Z
  id_comp' : ∀ {X Y} (f : Hom X Y), comp id f = f := by aesop_cat
  comp_id' : ∀ {X Y} (f : Hom X Y), comp f id = f := by aesop_cat
  assoc'   : ∀ {W X Y Z} (f : Hom W X) (g : Hom X Y) (h : Hom Y Z),
               comp (comp f g) h = comp f (comp g h) := by aesop_cat


Useage:

instance : Category Type where
  Hom := λ α β => α → β
  id := λ a => a
  comp := λ f g => g ∘ f

-/
