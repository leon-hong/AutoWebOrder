using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebOrder.Main
{
    public enum TYPE_WORK
    {
        Start = 0,
        ConnectSite,
        Login,
        ClearCart,
        CheckOrderItem,
        AddItemToCart,
        Payment,
        Complete,
        Count
    }

    class WorkManager
    {
        // TYPE_WORK 순서와 일치하는 work node들
        private List<WorkNodeBase> m_workNodes = new List<WorkNodeBase>();

        public WorkManager() {

            // TYPE_WORK 순서와 일치하도록 work node를 추가해 주세요
            m_workNodes.Add(new WorkNode.Start());
            m_workNodes.Add(new WorkNode.ConnectSite());
            m_workNodes.Add(new WorkNode.Login());
            m_workNodes.Add(new WorkNode.ClearCart());
            m_workNodes.Add(new WorkNode.CheckOrderItem());
            m_workNodes.Add(new WorkNode.AddItemToCart());
            m_workNodes.Add(new WorkNode.Payment());
            m_workNodes.Add(new WorkNode.Complete());

            for (int i = 0; i < (int)TYPE_WORK.Count; i++) {
                m_workNodes[i].Init( (TYPE_WORK)i, this);
            }
        }

        public void StartWork(WorkNodeArgment arg) {
            GoNextWork(TYPE_WORK.Start, arg);
        }

        public void GoNextWork(TYPE_WORK typeWork, WorkNodeArgment arg) {
            m_workNodes[(int)typeWork].Execute(arg);
        }
    }
}
