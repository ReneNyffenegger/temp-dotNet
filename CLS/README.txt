Common Language Specification

  Rules
    • 1: CLS rules apply only to those parts of a type that are accessible or visible outside of the defining assembly. 
    • 2: Members of non-CLS compliant types shall not be marked CLS-compliant
    • 3: Boxed value types are not CLS-compliant
    • 4: …
    • 48: If two or more CLS-compliant methods declared in a type have the same name and, for a specific set of type instantiations, they have the same parameter and return types, then all these methods shall be semantically equivalent at those type instantiations. 
