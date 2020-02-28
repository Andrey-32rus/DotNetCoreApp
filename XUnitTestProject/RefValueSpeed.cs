using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;
using XUnitTestProject.Models;

namespace XUnitTestProject
{
    public class RefValueSpeed
    {
        private int length = 1000000;
        private List<RefModel> refList;
        private List<ValueModel> valueList;

        public RefValueSpeed()
        {
            refList = ListFill<RefModel>(length);
            valueList = ListFill<ValueModel>(length);
        }

        private static List<T> ListFill<T>(int listLength) where T : new()
        {
            List<T> list = new List<T>(listLength);
            for (int i = 0; i < listLength; i++)
            {
                T model = new T();
                list.Add(model);
            }

            return list;
        }

        private static void ListForeach<T>(List<T> list)
        {
            foreach (var refModel in list)
            {
                var tmpModel1 = refModel;
                var tmpModel2 = refModel;
                var tmpModel3 = refModel;
                var tmpModel4 = refModel;
                var tmpModel5 = refModel;
            }
        }

        [Fact]
        public void RefListFill()
        {
            var list = ListFill<RefModel>(length);
        }

        [Fact]
        public void ValueListFill()
        {
            var list = ListFill<ValueModel>(length);
        }

        [Fact]
        public void RefListForeach()
        {
            ListForeach(refList);
        }

        [Fact]
        public void ValueListForeach()
        {
            ListForeach(valueList);
        }
    }
}
