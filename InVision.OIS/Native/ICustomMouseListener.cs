using System;
using InVision.Native.Ext;
using InVision.OIS.Attributes;

namespace InVision.OIS.Native
{
    [OISInterface("MouseListener")]
    public interface ICustomMouseListener : ICppInterface
    {
        [Constructor]
        ICustomMouseListener Construct(
            MouseMovedHandler mouseMoved, 
            MouseClickHandler mousePressed,
            MouseClickHandler mouseReleased);

        [Destructor]
        void Destruct();
    }
}