using System;
using System.Threading;
using Modding;
using Modding.PublicInterfaces.Cells;

namespace Indev2
{
    public class BreadCellProcessor : TickedCellStepper
    {

        public override string Name => "Bread Cell";
        public override int CellType => 10;
        public override string CellSpriteIndex => "Bread";


        public BreadCellProcessor(ICellGrid cellGrid) : base(cellGrid)
        {
        }

        public override bool OnReplaced(BasicCell basicCell, BasicCell existingCell)
        {
            _cellGrid.RemoveCell(existingCell);
            return false;
        }

        public override bool TryPush(BasicCell cell, Direction direction, int force)
        {
            cell.SpriteVariant = (short)Math.Min(2, force);
            _cellGrid.RemoveCell(cell);
            _cellGrid.AddCell(cell);
            return force > 2;
        }

        public override void OnCellInit(ref BasicCell cell)
        {
            //do nothing
        }

        public override void Clear()
        {
            //do nothing
        }

        public override void Step(CancellationToken ct)
        {
            var cells = GetCells();
            for (var index = 0; index < cells.Length; index++)
            {
                var cell = cells[index];
                cell.SpriteVariant = 0;
                _cellGrid.RemoveCell(cell);
                _cellGrid.AddCell(cell);
            }
        }
    }
}