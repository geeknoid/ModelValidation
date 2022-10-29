# Model Validation

This project outlines a simple design for effective model validation, aided by a source generator. It's main characteristics include:

* Simple to use with clear semantics.

* Simple to introduce new constraint annotations.

* High-quality diagnostics.

* Localization-friendly.

* Efficient as there are no allocations incurred when validation doesn't encounter errors.

* AOT-friendly, no reflection involved.

* Integration with DI for automatic validation of incoming options.

## How it works

* Developer creates a model

* Developer constrains the allowed value of individual fields/properties of the model using attributes.

* Developer annotates the type with the [MakeValidatable] attribute.

* The code generator emits the implementation of the IValidatable interface for the model, which verifies
the constraints declared by the developer and returns a detailed diagnostic if there are problems.

* Developer calls the generated Validate method on the model and inspects the results.

* The generated validator can be leveraged by dependency injection to ensure that options delivered through DI are
automatically validated before being delivered through DI, and that appropriate high-quality diagnostics
are delivered to the developer that's trying to load options into DI, either through code or through config.

## Gaps

Features likely needed but not shown in this sketch:

* The ability to validate models defined in other assemblies. This kind of 'foreign' validation
can easily be achieved via a few more annotations and can compose naturally.

* Integrating hand-written validation with the code generated ones. This is desirable to enable
developers to write more sophisticated constraints (such as those involving multiple field/properties).

## Example

See Program.cs for an example model with annotation, along with sample validation
