using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Smart.Design.Razor.TagHelpers.Constants;

namespace Smart.Application.Console
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListingHelper
    {
        public static IEnumerable< string > Run()
        {
            return GetConstants( typeof( TagNames ) ).ToList().Select( v => v.GetRawConstantValue() as string ).ToList();
        }

        private static IEnumerable< FieldInfo > GetConstants( System.Type type )
        {
            ArrayList constants = new ArrayList();

            FieldInfo[] fieldInfos = type.GetFields(
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.FlattenHierarchy );

            foreach ( FieldInfo fi in fieldInfos )
                if ( fi.IsLiteral && !fi.IsInitOnly )
                    constants.Add( fi );

            // Return an array of FieldInfos
            return ( FieldInfo[] ) constants.ToArray( typeof( FieldInfo ) );
        }
    }
}
