module Curring

let f x y = x + y
let curry f x =
    let f2 y = f x y
    f2

let f2 = curry f 5
let res = f2 6 = f 5 6
let f3 = f 5
let res2 = f3 6 = f 5 6

let plusWithLogging (log: int -> unit) x y =
    log x
    log y
    x + y

let multWithLogging log x y =
    log x
    log y
    x * y

let mathForList f: int list =
    [(1, 5); (2, 10); (3, 100)] |> List.map (fun (x, y) -> f x y)

let logProd (x: int) = ()
let logTest (x: int) = System.Console.WriteLine(x)

let runCode log =
    let plus = plusWithLogging log
    let mult = multWithLogging log
    let list: int list = [mathForList plus; mathForList mult] |> List.concat
    list

let test = runCode logTest
let prod = runCode logProd

type Record = {A: int; B: string}

let r1 = {A = 1; B = "str"}
let r2 = {A = 1; B = "str"}
let r3 = {A = 1; B = "str2"}
let r4 = {r1 with A = 10}

type Option<'a> =
    |Some of 'a
    |None

type Result<'res, 'err> =
    |Ok of 'res
    |Error of 'err

let map f x =
    match x with
    |Some x ->
        Some (f x)
    |None ->
        None

