module Base
    open Helpers

    let var = 5
    let nested = //everithing is expresions.
        let var = 5 // indention                     // this
        let var2 = 6                                 // is
        let var = var + var2 //shadowing             // expression
        var                                          // too

    //System.Console.WriteLine(var2) // error var 2 is not defined

    let ifdemo = if nested < 11 then 456587 else 4583

    let f x y = x + y // type inference
    let inline f' x y = x + y // even better with inline

    let tuple = (5, 6)
    let (fst, scnd) = tuple // let binding is pattern matching btw
    
    let f'' (x: int*int) =
        match x with
        |(fst, scnd) -> fst + scnd

    let f''' (fst, snd) = fst + snd // passing params to func is also pattern matching

    let list = [1; 2; 3]
    let list' = []
    let list'' = [1 .. 10]
    let list''' = [1 .. 10 .. 100]
    let list'''' = [5 + 98; f 55 55; if 5 > 7 then 8 else 99] // any expression in list construct
    let list1 = [for i in 1 .. 10 -> i * i]
    let list1' = [
        for i in 1 .. 10 do i;
        for i in 12 .. 2 .. 20 do i
        ]
    let list1'' = [for n in 1 .. 100 do if n % 2 = 0 then n]
    let list1''' = [
        for x in 1..10 do
            yield x
            yield! [for i in 1..x -> i]
    ]

    let labmdaFunc = (fun x -> x % 2 = 0)
    let filtered1 = list'' |> List.filter labmdaFunc
    let filtered2 = List.filter (fun x -> x % 2 = 0) list''
    let eq = filtered1 = filtered2

    let plust = (+) 6 7
    let pipe = 6 |> (+) 7 |> (*) 8
    
    let (|>>) x f = f x 
    let ourPipe = 6 |>> (+) 7 |>> (*) 8

    let comFun = (+) 7 >> (*) 8
    let combine = comFun 6
    let (>>>) f1 f2 x = f2(f1 x)
    let comFun2 = (+) 7 >>> (*) 8
    let outCombine = comFun2 6

    let opt = Some 1
    let opt2 = None;

    let str =
        match opt with
        |Some x ->
            (x + 6).ToString()
        |None ->
            "poshli nax"

    let comp1 = optionCmpt {
        let! x = Some 5
        let! y = Some 6
        return x + y
    }

    let comp2 = optionCmpt {
        let! x = Some 5
        let! y = None
        return x + y
    }

    let traverseExample = [Some 1; Some 2; Some 3] |> traverseOpt id
    let traverseExample2 = [Some 1; None; Some 3] |> traverseOpt id

    let choose = [1; 2; 3; 4; 5] |> List.choose (fun x -> if x % 2 = 0 then Some x else None)

    let plus5 = (+) 5
    //let result = plus5 opt // error

    let plus5opt = Option.map plus5
    let result = plus5opt opt
    let result' = opt |> Option.map plus5

    let (>>=) x f = x |> Option.bind f

    let bind =
        Some 5 >>= (fun x ->
        Some 6 >>= (fun y ->
        Some (x + y)))