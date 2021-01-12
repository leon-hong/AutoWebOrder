using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebOrder
{
    public class OrderData
    {
        public string pathOrder { set; get; }               // 주문서 경로
        public string seller { set; get; }                  // 판매 업체 이름
        public List<string> listSerial { set; get; }        // 주문 시리얼 넘버    
        public List<string> listName  { set; get; }        // 제품명
        public List<string> listAmount { set; get; }        // 수량
        public List<string> listCategory { set; get; }      // 분류
        public List<string> listSeller { set; get; }        // 공급자
        public List<string> listCode { set; get; }         // 공급코드

        public OrderData() {
            listSerial = new List<string>();       
            listName = new List<string>();         
            listAmount = new List<string>();       
            listCategory = new List<string>();     
            listSeller = new List<string>();
            listCode = new List<string>();              
        }

        public int GetCount() {
            return listSerial.Count;
        }

        public void RemoveAt(int idx) {
            listSerial.RemoveAt(idx);
            listName.RemoveAt(idx);
            listAmount.RemoveAt(idx);
            listCategory.RemoveAt(idx);
            listSeller.RemoveAt(idx);
            listCode.RemoveAt(idx);
        }

        // 공급업자의 이름을 가지고 있는 데이터만 남기고 버림
        public void FilterBySeller(string filter) {

            this.seller = filter;
            int cnt = listSerial.Count;

            if (0 == cnt) {
                return;
            }

            for (int i = cnt - 1; i >= 0; i--) {
                if (false == listSeller[i].Contains(filter)) {
                    listSerial.RemoveAt(i);
                    listName.RemoveAt(i);
                    listAmount.RemoveAt(i);
                    listCategory.RemoveAt(i);
                    listSeller.RemoveAt(i);
                    listCode.RemoveAt(i);
                }
            }
        }

    }
}
