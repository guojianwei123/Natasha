﻿using Natasha.Builder;
using System;

namespace Natasha.Operator
{
    /// <summary>
    /// 快速创建一个动态方法
    /// </summary>
    public class FastMethodOperator : OnceMethodBuilder<FastMethodOperator>
    {

        public static FastMethodOperator MainDomain
        {
            get
            {

                return new FastMethodOperator();

            }
        }


        public static FastMethodOperator RandomDomain
        {

            get
            {
                var result = new FastMethodOperator(true);
                result.Complier.Domain = DomainManagment.Create("N" + Guid.NewGuid().ToString("N"));
                return result;
            }

        }




        public FastMethodOperator(bool inCache = false) : base(inCache)
        {

            Link = this;
            Public
                .Static
                .PublicMember
                .StaticMember
                .UseRandomOopName()
                .HiddenNameSpace();

        }



        public override T Complie<T>(object binder = null)
        {

            var method = typeof(T).GetMethod("Invoke");
            if (ParametersMappings.Count == 0)
            {

                Param(method);

            }


            if (ReturnScript == default)
            {

                Return(method.ReturnType);

            }
            return base.Complie<T>(binder);

        }

    }

}
