using System;

namespace FuncCompose {
    public static class Extensions {

        public static Func<A, C> Compose<A, B, C>(this Func<A, B> source, Func<B, C> target) {
            return (a) => target(source(a));
        }

        public static Func<A, bool> And<A>(this Func<A, bool> source, Func<A, bool> target) {
            return (a) => {
                var rs = source(a);
                var rs2 = target(a);
                return rs && rs2;
            };
        }

        public static Func<A, bool> Or<A>(this Func<A, bool> source, Func<A, bool> target) {
            return (a) => {
                var rs = source(a);
                var rs2 = target(a);
                return rs || rs2;
            };
        }
    }
}