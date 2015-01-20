using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BannyPotter.DBS.Core.Tests
{
    [TestClass]
    public class StatusCheckProcessorTests
    {
        private IStatusCheckProcessor _processor;

        [TestInitialize]
        public void Init()
        {
            _processor = new StatusCheckProcessor();
        }
    }
}
