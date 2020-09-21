namespace Tfc.Types

module Records =
    
    type IAddress =
        abstract member Street: string
        abstract member City: string
        abstract member State: string
        abstract member PostalCode: string

    type Customer = 
        { Id: int
          FirstName: string
          LastName: string 
          Address: Address
        }
        static member Default =
            {
                Id = 0
                FirstName = "Spongebob"
                LastName = "Squarepants"
                Address = Address.Default
            }
        member this.PrintMe() =
            printfn "%d - %s %s" this.Id this.FirstName this.LastName
    and Address = 
        {
            Street: string
            City: string
            State: string
            PostalCode: string
        }
        static member Default =
            {
                Street = "124 Conch St"
                City = "Bikini Bottom"
                State = "Disarray"
                PostalCode = "10101"
            }
        interface IAddress with 
            member this.Street = this.Street
            member this.City = this.City
            member this.State = this.State
            member this.PostalCode = this.PostalCode

    type AnotherCustomer =
        { Id: int
          FirstName: string
          LastName: string 
          Address: Address
        }

    type ClassCustomer(id, firstName, lastName, address) =
        member __.Id = id
        member __.FirstName = firstName
        member __.LastName = lastName
        member __.Address = address


    let printStuff() =
        let customer = { Customer.Id = 1; FirstName = "Rocky"; LastName = "Balboa"; Address = Address.Default }
        printfn "%A" customer

        let customer1 = { customer with Customer.Id = 2; FirstName = "Adrian"; LastName = "Balboa" }
        printfn "%A" customer1

        let samecustomer = { Customer.Id = 1; FirstName = "Rocky"; LastName = "Balboa"; Address = Address.Default }

        printfn "%b" (customer = samecustomer)
                
        let classCustomer1 = ClassCustomer(4, "first", "last", Address.Default)
        let classCustomer2 = ClassCustomer(4, "first", "last", Address.Default)

        printfn "%b" (classCustomer1 = classCustomer2)

