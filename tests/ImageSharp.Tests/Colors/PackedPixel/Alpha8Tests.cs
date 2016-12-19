// <copyright file="Alpha8Tests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.Colors.PackedPixel
{
    using Xunit;

    public class Alpha8Tests
    {
        public static readonly TheoryData<float, float> PackedValues = 
            new TheoryData<float, float>
            {
                // Test the limits.
                { 0F, 0x0 },
                { 1F, 0xFF },
                // Test clamping.
                { -1234F, 0x0 },
                { 1234F, 0xFF },
                // Test ordering
                { 124F / 0xFF, 124 },
                { 0.1F, 26 },
            };

        public static readonly TheoryData<int, ComponentOrder, byte[]> BytesValues =
            new TheoryData<int, ComponentOrder, byte[]>()
            {
                { 3, ComponentOrder.XYZ, new byte[] { 0, 0, 0 } },
                { 3, ComponentOrder.ZYX, new byte[] { 0, 0, 0 } },
                { 4, ComponentOrder.XYZW, new byte[] { 0, 0, 0, 128 } },
                { 4, ComponentOrder.ZYXW, new byte[] { 0, 0, 0, 128 } },
            };

        public static readonly TheoryData<float> ToVector4Data =
            new TheoryData<float>()
            {
                { 0.5F },
                { 0.1F },
                { 0.2F },
            };

        [Theory]
        [MemberData("PackedValues")]
        public void PackedValue(float alphaValue, float expectedPackedValue)
        {
            // Arrange 
            var alpha8 = new Alpha8(alphaValue);

            // Act
            var packedValue = alpha8.PackedValue;

            // Assert
            Assert.Equal(expectedPackedValue, packedValue);
        }

        [Theory]
        [MemberData("ToVector4Data")]
        public void ToVector4(float alphaValue)
        {
            // Arrange 
            var precision = 2;
            var alpha8 = new Alpha8(alphaValue);
                
            // Act
            var vector = alpha8.ToVector4();

            // Assert
            Assert.Equal(vector.X, 0);
            Assert.Equal(vector.Y, 0);
            Assert.Equal(vector.Z, 0);
            Assert.Equal(vector.W, alphaValue, precision);
        }

        [Theory]
        [MemberData("BytesValues")]
        public void ToBytes(
            int bytesSize, 
            ComponentOrder componentOrder, 
            byte[] expectedBytes)
        {
            // Arrange
            var alpha = new Alpha8(.5F);
            var bytes = new byte[bytesSize];
            
            // Act
            alpha.ToBytes(bytes, 0, componentOrder);

            // Assert
            Assert.Equal(expectedBytes, bytes);
        }
    }
}
