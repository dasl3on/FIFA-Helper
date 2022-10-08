using System;

namespace FIFA_Helper.Exceptions {
    public class OriginNotFoundException : Exception {
        public OriginNotFoundException() : base("Path to Origin client not found") { }

    }
}
