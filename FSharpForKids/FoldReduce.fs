module FoldReduce

let res = [1; 2; 5; 6; 7; 8] |> List.fold (fun str num -> sprintf "%s%i," str num) ""
let res2 = [1; 2; 5; 6; 7; 8] |> List.reduce (fun sum x -> sum + x)

