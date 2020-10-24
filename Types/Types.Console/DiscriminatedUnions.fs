namespace Tfc.Types

module DiscriminatedUnions =

    let pi = 3.14159m

    type Shape = 
        | Circle of radius:decimal
        | Square of side:decimal
        | Triangle of ``base``:decimal * height:decimal
        member this.ExampleMember () = ()

    module Shape =
        let calculateArea1 shape =
            match shape with 
            | Circle radius -> pi * radius * radius
            | Square side -> side * side
            | Triangle (b,h) -> 0.5m * b * h

        let calculateArea = function
            | Circle radius -> pi * radius * radius
            | Square side -> side * side
            | Triangle (b,h) -> 0.5m * b * h

        let printArea shape = 
            let area = shape |> calculateArea
            printfn "Area: %f" area


    let printStuff () =
        let myCircle = Circle 1m
        myCircle |> Shape.printArea
        Square 5m |> Shape.printArea
        Triangle (2m,3m) |> Shape.printArea

    type Street = Street of string
    module Street =
        let create street = Street street
        let value (Street street) = street

    type City = City of string
    module City =
        let create city = City city
        let value (City city) = city

    type State = State of string
    module State =
        let create state = State state
        let value (State state) = state
    
    type PostalCode = PostalCode of string
    module PostalCode =
        let create postalCode = PostalCode postalCode
        let value (PostalCode postalCode) = postalCode

    type Address =
        {
            Street: Street
            City: City
            State: State
            PostalCode: PostalCode
        }


