﻿open System.IO
type Observation = { Label:string; Pixels: int[] }
type Distance = int[] * int[] -> int
type Classifier = int[] -> string

let toObservation (csvData:string) =
    let columns = csvData.Split(',')
    let label = columns.[0]
    let pixels = columns.[1..] |> Array.map int
    { Label = label; Pixels = pixels }

let reader path =
    let data = File.ReadAllLines path 
    data.[ 1..] |> Array.map toObservation 

let trainingPath = @"/Users/scampbell/CODE/fsharp_machineLearningBook/data/trainingsample.csv" 
let trainingData = reader trainingPath

let manhattanDistance (pixels1, pixels2) = 
    Array.zip pixels1 pixels2
    |> Array.map (fun (x,y) -> abs (x-y))
    |> Array.sum

let euclideanDistance (pixels1,pixels2) =
    Array.zip pixels1 pixels2
    |> Array.map (fun (x,y) -> pown (x-y) 2)
    |> Array.sum

let train (trainingset:Observation[]) (dist:Distance) = 
    let classify (pixels:int[]) =
        trainingset
        |> Array.minBy (fun x -> manhattanDistance (x.Pixels, pixels))
        |> fun x -> x.Label
    classify

let classifier = train trainingData

let validationPath = @"/Users/scampbell/CODE/fsharp_machineLearningBook/data/validationsample.csv"
let validationData = reader validationPath
let evaluate validationSet classifier = 
    validationSet
    |> Array.averageBy (fun x -> if classifier x.Pixels = x.Label then 1. else 0.)
    |> printfn "Correct: %.3f"

let manhattanModel = train trainingData manhattanDistance
let euclideanModel = train trainingData euclideanDistance

printfn "Manhattan"
evaluate validationData manhattanModel
printfn "Euclidean"
evaluate validationData euclideanModel

// Illustration: full distance function

let d (X,Y) = 
    Array.zip X Y 
    |> Array.map (fun (x,y) -> pown (x-y) 2) 
    |> Array.sum 
    |> sqrt
