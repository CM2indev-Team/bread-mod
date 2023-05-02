using System;
using System.Collections.Generic;
using Indev2;
using Modding;


//MUST BE NAMED MOD
public class Mod : IMod
{
    public static Interface Interface;
    public string UniqueName => "BreadMod";
    public string DisplayName => "BreadMod";
    public string Author => "Mystic";
    public string Version => "5.0";
    public string Description => "Bread mod";
    public string[] Dependencies => Array.Empty<string>();

    public void Initialize(Modding.Interface @interface)
    {
        Interface = @interface;
    }

    public IEnumerable<CellProcessor> GetCellProcessors(ICellGrid cellGrid)
    {
        yield return new BasicCellProcessor(cellGrid);
        yield return new SlideCellProcessor(cellGrid);
        yield return new BreadCellProcessor(cellGrid);
        yield return new FreezeProcessor(cellGrid);
        yield return new GeneratorCellProcessor(cellGrid);
        yield return new CWRotateProcessor(cellGrid);
        yield return new CCWRotateProcessor(cellGrid);
        yield return new MoverCellProcessor(cellGrid);
        yield return new WallCellProcessor(cellGrid);
        yield return new TrashCellProcessor(cellGrid);
        yield return new EnemyCellProcessor(cellGrid);
    }
}
