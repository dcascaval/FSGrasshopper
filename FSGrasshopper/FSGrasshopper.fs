namespace Library1

open System
open Rhino.Geometry
open FSharp.Collections
open Grasshopper.Kernel


type FSComponentExample() =
  inherit Grasshopper.Kernel.GH_Component(
    "FSharpExample","FSX","Test GH Plugin Development in F#",
    "FSharpExample","Function" 
  )

  override this.RegisterInputParams pManager = 
    pManager.AddIntegerParameter("NumPts","N","Number of Points",GH_ParamAccess.item) |> ignore
    pManager.AddNumberParameter("PSize","P","Point Range",GH_ParamAccess.item) |> ignore
    ()

  override this.RegisterOutputParams pManager = 
    pManager.AddPointParameter("FPoint","F","FSharp Points",GH_ParamAccess.list) |> ignore
    ()

  override this.SolveInstance DA = 
    let n,s = ref 0,ref 0.0 in
    let b1,b2 = DA.GetData(0,n), DA.GetData(1,s) in
    if not (b1 && b2) then ()
    else
      let num,size = !n,(double !s) in
      let pts = seq { for i in 0..num -> let p = size * (double i) / (double num) in Point3d(p,p,p) } in
      DA.SetDataList(0,pts) |> ignore
    ()
    
  override this.Icon = null
  override this.ComponentGuid = Guid("7BE0D101-02F0-428E-B42F-8F2EBD608B0B")