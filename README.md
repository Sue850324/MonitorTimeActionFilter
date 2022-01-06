# Monitor Time Action Filter To Do List
- [x] 讓寫入功能的 action 做延遲一秒回應給 client
- [x] 做一個效能監控 filter，執行時間超過5秒的發送告警，email、line、telegram 擇一
- [x] 發送告警改為彈性置換管道，透過修改 autofac 的註冊服務，調整發送管道而不動到原本的發送程式碼 
