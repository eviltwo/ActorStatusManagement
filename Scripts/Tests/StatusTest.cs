using NUnit.Framework;

namespace ActorStatusManagement.Tests
{
    public class StatusTest
    {
        private string _statusKey = "DummyKey";

        [Test]
        public void SameStatusWhenNotModified()
        {
            var status = new Status();
            status.SetDefaultValue(_statusKey, 1);
            status.Calculate();
            Assert.AreEqual(1, status.GetDefaultValue(_statusKey));
            Assert.AreEqual(1, status.GetModifiedValue(_statusKey));
        }

        [Test]
        public void DifferentStatusWhenModified()
        {
            var status = new Status();
            status.SetDefaultValue(_statusKey, 1);
            status.OnModifyStatus += s => s.ModifyValue(_statusKey, 2);
            status.Calculate();
            Assert.AreEqual(1, status.GetDefaultValue(_statusKey));
            Assert.AreEqual(2, status.GetModifiedValue(_statusKey));
        }
    }
}
