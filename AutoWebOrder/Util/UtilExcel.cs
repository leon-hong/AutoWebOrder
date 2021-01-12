using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace AutoWebOrder.Util
{

    // 엑셀 시트1개짜리 데이터 처리 클래스
    class UtilExcel
    {

        //public static bool GetColumDatas(string path, int idxColum, List<string> outList) {

        //    outList.Clear();

        //    // 엑셀 객체는 하나의 메서드에서만 열고 지워야, 프로세스에 엑셀 프로세스가 남지 않음
        //    // 엑셀의 첫번째 시트 가져오기
        //    // 첫번째 시트는 인덱스가 1 (프로그램 인덱스와 다름)
        //    Application app = new Application();
        //    Workbook workbook = app.Workbooks.Open(path);
        //    Worksheet sheet = workbook.Sheets[1];
        //    Range range = sheet.UsedRange;
        //    int cntRow = range.Rows.Count;

        //    // 시작 인덱스가 1인데, 1은 타이틀이므로 2부터 시작
        //    // 비어있는값은 오류이므로 처리해줌
        //    for (int i = 2; i <= cntRow; i++) {
        //        string value = (range.Cells[i, idxColum] as Range).Value2 == null ? "" : (range.Cells[i, idxColum] as Range).Value2.ToString();
        //        outList.Add(value);
        //    }

        //    // 필수 사용한 자원 지우기
        //    // 이거 안하면 프로세스에서 엑셀파일을 잡고 있어서 그 엑셀파일을 편집을 못하게됨
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
        //        GC.Collect();
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
        //        GC.Collect();
        //        app.Quit();
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        //        GC.Collect();

        //        return true;
        //    }
        //    catch (Exception ex) {
        //        app.Quit();
        //        return false;                
        //    }            

        //}

        public static bool GetColumDatas(string path
            ,int idxSerial, List<string> outSerial
            ,int idxName, List<string> outName
            ,int idxAmount, List<string> outAmount
            ,int idxCategory, List<string> outCategory
            ,int idxCode, List<string> outCode
            ,int idxSeller, List<string> outSeller )
        {

            outSerial.Clear();
            outName.Clear();
            outAmount.Clear();
            outCategory.Clear();
            outCode.Clear();
            outSeller.Clear();

            // 엑셀 객체는 하나의 메서드에서만 열고 지워야, 프로세스에 엑셀 프로세스가 남지 않음
            // 엑셀의 첫번째 시트 가져오기
            // 첫번째 시트는 인덱스가 1 (프로그램 인덱스와 다름)
            Application app = new Application();
            Workbook workbook = app.Workbooks.Open(path);
            Worksheet sheet = workbook.Sheets[1];
            Range range = sheet.UsedRange;
            int cntRow = range.Rows.Count;

            // 시작 인덱스가 1인데, 1은 타이틀이므로 2부터 시작
            // 비어있는값은 오류이므로 처리해줌
            for (int i = 2; i <= cntRow; i++)
            {
                dynamic val = (range.Cells[i, idxSerial] as Range).Value2;                
                outSerial.Add((val == null) ? "" : val.ToString());

                val = (range.Cells[i, idxName] as Range).Value2;
                outName.Add((val == null) ? "" : val.ToString());

                val = (range.Cells[i, idxAmount] as Range).Value2;
                outAmount.Add((val == null) ? "" : val.ToString());

                val = (range.Cells[i, idxCategory] as Range).Value2;
                outCategory.Add((val == null) ? "" : val.ToString());

                val = (range.Cells[i, idxCode] as Range).Value2;
                outCode.Add((val == null) ? "" : val.ToString());

                val = (range.Cells[i, idxSeller] as Range).Value2;
                outSeller.Add((val == null) ? "" : val.ToString());
            }

            // 필수 사용한 자원 지우기
            // 이거 안하면 프로세스에서 엑셀파일을 잡고 있어서 그 엑셀파일을 편집을 못하게됨
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                GC.Collect();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                GC.Collect();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                GC.Collect();

                return true;
            }
            catch (Exception ex)
            {
                app.Quit();
                return false;
            }

        }


        public static bool ListViewToExcel(System.Windows.Forms.ListView listview , string path) {
            
            Application app = new Application();
            Workbook workbook = app.Workbooks.Add();
            Worksheet sheet = workbook.Worksheets.Add();


            // 컬럼명 설정
            for (int j = 0; j < listview.Columns.Count; j++) {
                sheet.Cells[1, j + 1] = listview.Columns[j].Text;
            }

            // 엑셀은 시작 인덱스가 1인데, 컬럼빼고 시작하면 2행 부터 데이터
            for (int i = 0; i < listview.Items.Count; i++)
            {
                for (int j = 0; j < listview.Columns.Count; j++)
                {                    
                    sheet.Cells[i + 2, j + 1] = listview.Items[i].SubItems[j].Text;                    
                }
            }

            sheet.Columns.AutoFit();
            workbook.SaveAs(path, XlFileFormat.xlWorkbookDefault);
            workbook.Close();

            // 필수 사용한 자원 지우기
            // 이거 안하면 프로세스에서 엑셀파일을 잡고 있어서 그 엑셀파일을 편집을 못하게됨
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                GC.Collect();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                GC.Collect();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                GC.Collect();

                return true;
            }
            catch (Exception ex)
            {
                app.Quit();
                return false;
            }
        }

    }
}
