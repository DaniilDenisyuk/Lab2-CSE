using System;
using IIG.BinaryFlag;
using Xunit;

namespace Lab2
{
    public class BlackBoxBinaryFlagTest
    {
        [Theory]
        [InlineData(18446744073709551615)]
        public void MBF_Constructor_ULongLengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        [Theory]
        [InlineData(17179868704)]
        public void MBF_Constructor_MaxLengthTest(ulong l)
        {
            var mbf = new MultipleBinaryFlag(l);
            Assert.True(mbf.GetFlag());
        }
        [Theory]
        [InlineData(17179868705)]
        public void MBF_Constructor_MaxLengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        [Theory]
        [InlineData(2)]
        public void MBF_Constructor_MinLengthTest(ulong l)
        {
            var mbf = new MultipleBinaryFlag(l);
            Assert.True(mbf.GetFlag());
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void MBF_Constructor_LengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        
        [Theory]
        [InlineData(100, true)]
        [InlineData(400, true)]
        [InlineData(213, true)]
        public void MBF_Constructor_Length_ResTrue(ulong l, bool v)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(100, false)]
        [InlineData(400, false)]
        [InlineData(213, false)]
        public void MBF_Constructor_Length_ResFalse(ulong l, bool v)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(400, false, false)]
        [InlineData(400, true, true)]
        [InlineData(2, false, true)]
        public void MBF_GetFlag_SetFlag(ulong l, bool v, bool expected)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
            mbf.SetFlag(0);
            mbf.SetFlag(1);
            Assert.Equal(expected, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(400, false, false)]
        [InlineData(400, true, false)]
        [InlineData(2, true, false)]
        public void MBF_GetFlag_ResetFlag(ulong l, bool v, bool expected)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
            mbf.ResetFlag(1);
            Assert.Equal(expected, mbf.GetFlag());
        }

        [Theory]
        [InlineData(400, false, false)] 
        [InlineData(400, true, true)] 
        [InlineData(2, true, true)]
        public void MBF_GetFlag_SetFlag_ResetFlag(ulong l, bool v, bool expected)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
            mbf.ResetFlag(1);
            mbf.SetFlag(1);
            Assert.Equal(expected, mbf.GetFlag());
        }
    }
}
