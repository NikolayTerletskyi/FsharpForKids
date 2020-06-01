module PatternMatching

let x = 
    match 1 with 
    | 1 -> "a"
    | 2 -> "b"  
    | _ -> "z" 

let y = 
    match 1 with
    | _ -> "z" 
    | 1 -> "a"
    | 2 -> "b" 
    
//let x = 
//    match 1 with 
//    | 1 -> 42
//    | 2 -> true  // error wrong type
//    | _ -> "hello" // error wrong type

//incomplete match
let z = 
    match 42 with 
    | 1 -> "a"
    | 2 -> "b"


type Choices = A | B | C
let k = 
    match A with 
    | A -> "a"
    | B -> "b"
    | C -> "c"

let l = 
    match (1,0) with 
    | (1,x) -> printfn "x=%A" x

let p = 
    match (1,0) with 
    | (2,x) | (3,x) | (4,x) -> printfn "x=%A" x 
    | (2,x) & (_,1) -> printfn "x=%A" x 


let lst = 
    match [1;2;3] with
    | [1;x;y] -> printfn "x=%A y=%A" x y
    | 1::tail -> printfn "tail=%A" tail 
    | [] -> printfn "empty" 

let rec loopAndPrint aList = 
    match aList with 
    | [] -> 
        printfn "empty" 
    | x::xs -> 
        printfn "element=%A," x
        loopAndPrint xs 


type Person = {First:string; Last:string}
let person = {First="john"; Last="doe"}
match person with 
| {First="john"}  -> printfn "Matched John" 
| _  -> printfn "Not John" 

type IntOrBool= I of int | B of bool
let intOrBool = I 42
match intOrBool with 
| I i  -> printfn "Int=%i" i
| B b  -> printfn "Bool=%b" b

let r = 
    match (1,0) with 
    | (x,y) as t -> 
        printfn "x=%A and y=%A" x y
        printfn "The whole tuple is %A" t


let x' = System.Object()
let y' = 
    match x' with 
    | :? System.Int32 as _int-> 
        printfn "matched an int"
    | :? System.DateTime -> 
        printfn "matched a datetime"
    | _ -> 
        printfn "another type"

let elementsAreEqual aTuple = 
    match aTuple with 
    | (x,y) when x=y -> 
        printfn "both parts are the same" 
    | _ ->
        printfn "both parts are different" 


let classifyString aString = 
    match aString with 
    | x when System.Text.RegularExpressions.Regex.Match(x,@".+@.+").Success-> 
        printfn "%s is an email" aString
    | _ -> 
        printfn "%s is something else" aString


let (|EmailAddress|_|) input =
   let m = System.Text.RegularExpressions.Regex.Match(input,@".+@.+") 
   if (m.Success) then Some input else None  

let classifyString' aString = 
    match aString with 
    | EmailAddress x -> 
        printfn "%s is an email" x
    | _ -> 
        printfn "%s is something else" aString

let f aValue = 
    match aValue with 
    | _ -> "something" 

let f' = 
    function 
    | _ -> "something" 

let q = [2..10] |> List.map (function 
                | 2 | 3 | 5 | 7 -> sprintf "prime"
                | _ -> sprintf "not prime")