module Helpers

    type OptionBuilder () =
        member this.Return x = Some x
        member this.ReturnFrom x = x
        member this.Bind (x, f) = Option.bind f x

    let optionCmpt = OptionBuilder ()

    type ResultBuilder () =
        member this.Return x = Ok x
        member this.ReturnFrom x = x
        member this.Bind (x, f) = Result.bind f x

    let result = ResultBuilder ()

    let traverseOpt f ls =
        let (>>=) r f = Option.bind f r
        let rtn v     = Some v
        let folder head tail = f head >>= (fun h -> tail >>= (fun t -> h::t |> rtn))
        List.foldBack folder ls (rtn List.empty)

    let traverseRes f ls =
        let (>>=) r f = Result.bind f r
        let rtn v     = Ok v
        let folder head tail = f head >>= (fun h -> tail >>= (fun t -> h::t |> rtn))
        List.foldBack folder ls (rtn List.empty)