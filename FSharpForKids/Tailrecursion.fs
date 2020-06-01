module Tailrecursion

let rec tailFib one two count =
    if count > 2L then
        tailFib two (one + two) (count - 1L)
    else
        one + two

let rec notTailFib one two count =
    if count > 2L then
        let res = tailFib two (one + two) (count - 1L)
        (res + 5) * 3
    else
        one + two