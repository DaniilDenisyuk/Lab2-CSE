using System;
using Xunit;
using IIG.BinaryFlag;

namespace Lab2
{
    public class UnitTest1
    {
        private MultipleBinaryFlag _multipleBinaryFlag;
        public UnitTest1()
        {
            _multipleBinaryFlag = new MultipleBinaryFlag(10);
        }
        [Fact]
        public void Test1()
        {
            Assert.True(_multipleBinaryFlag.GetFlag());
            _multipleBinaryFlag.ResetFlag(4);
            Assert.False(_multipleBinaryFlag.GetFlag());
            _multipleBinaryFlag.SetFlag(4);
            Assert.True(_multipleBinaryFlag.GetFlag());
            _multipleBinaryFlag.Dispose();
            //OBJECT IS NOT DISPOSED!!!
            Assert.Null(_multipleBinaryFlag);
            _multipleBinaryFlag = new MultipleBinaryFlag(5, false);
            Assert.False(_multipleBinaryFlag.GetFlag());
        }
    }
}
