using System;
using IIG.BinaryFlag;
using Xunit;

namespace Lab2
{
    public class BlackBoxBinaryFlagTest
    {
        [Theory]
        [InlineData(ulong.MaxValue)]
        [InlineData(ulong.MaxValue - 1)]
        public void MBF_Constructor_MaxULongLengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        
        [Theory]
        [InlineData(ulong.MinValue)]
        [InlineData(ulong.MinValue + 1)]
        public void MBF_Constructor_MinULongLengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        
        [Theory]
        [InlineData(17179868703)]
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
        [InlineData(3)]
        public void MBF_Constructor_MinLengthTest(ulong l)
        {
            var mbf = new MultipleBinaryFlag(l);
            Assert.True(mbf.GetFlag());
        }
        [Theory]
        [InlineData(1)]
        public void MBF_Constructor_MinLengthTest_Exception(ulong l)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(l));
        }
        
        [Theory]
        [InlineData(100, true)]
        [InlineData(400, true)]
        [InlineData(213, true)]
        public void MBF_Constructor_TrueInit(ulong l, bool v)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(100, false)]
        [InlineData(400, false)]
        [InlineData(213, false)]
        public void MBF_Constructor_FalseInit(ulong l, bool v)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(17179868704, true, ulong.MinValue)]
        [InlineData(17179868704, true, 17179868703)] 
        [InlineData(17179868704, true, 21214215)]
        public void MBF_SetFlag_ResetFlag(ulong l, bool v, ulong pos)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Equal(v, mbf.GetFlag());
            mbf.ResetFlag(pos);
            Assert.False(mbf.GetFlag());
            mbf.SetFlag(pos);
            Assert.Equal(v, mbf.GetFlag());
        }
        
        [Theory]
        [InlineData(17179868704,true, ulong.MaxValue)]
        [InlineData(17179868704,true, 17179868704)]
        public void MBF_SetFlag_ResetFlag_Exception(ulong l, bool v, ulong pos)
        {
            var mbf = new MultipleBinaryFlag(l, v);
            Assert.Throws<ArgumentOutOfRangeException>(() => mbf.SetFlag(pos));
            Assert.Throws<ArgumentOutOfRangeException>(() => mbf.ResetFlag(pos));
        }
    }
}
