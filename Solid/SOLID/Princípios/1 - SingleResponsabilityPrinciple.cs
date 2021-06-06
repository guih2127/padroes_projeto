namespace SOLID.Princípios
{
    public class SingleResponsabilityPrinciple
    {
        // Nossa classe ordem não respeita o princípio de responsabilidade única, pois realiza 3 tipos distintos de tarefas:
        // Além de lidar com as informações do pedido, ela também é responsável pela exibição e manipulação dos dados.
    }

    class Order
    {
        public void calculateTotalSum() {/*...*/}
        public void getItems() {/*...*/}
        public void getItemCount() {/*...*/}
        public void addItem(object item) {/*...*/}
        public void deleteItem(object item) {/*...*/}

        public void printOrder() {/*...*/}
        public void showOrder() {/*...*/}

        public void load() {/*...*/}
        public void save() {/*...*/}
        public void update() {/*...*/}
        public void delete() {/*...*/}
    }

    // Nossa nova classe ordem foi refatorada, respeitando o princípio de responsabilidade única.
    // Criamos duas novas classes, cada uma para realizar um tipo distinto de tarefa.

    class OrderRefatorated
    {
        public void calculateTotalSum() {/*...*/}
        public void getItems() {/*...*/}
        public void getItemCount() {/*...*/}
        public void addItem(object item) {/*...*/}
        public void deleteItem(object item) {/*...*/}
    }

    class OrderRepository
    {
        public void load(object item) {/*...*/}
        public void save(object item) {/*...*/}
        public void update(object item) {/*...*/}
        public void delete(object item) {/*...*/}
    }

    class OrderViewer
    {
        public void printOrder(object item) {/*...*/}
        public void showOrder(object item) {/*...*/}
    }
}
