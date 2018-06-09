using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Engine.Data.TypeMappers
{
        public class PageAddressTypeMapper : SqlMapper.TypeHandler<PageAddress>
        {
            private PageAddressTypeMapper()
            {
            }

            public static readonly PageAddressTypeMapper Default = new PageAddressTypeMapper();

            public override void SetValue(IDbDataParameter parameter, PageAddress value)
            {
                parameter.Value = value.ToString();
            }

            public override PageAddress Parse(object value)
            {
                return new PageAddress((byte[])value);
            }
        }
    }
