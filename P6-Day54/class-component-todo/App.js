import { Component } from "react";
import TodoInput from "./components/TodoInput";
import TodoList from "./components/TodoList";

import "bootstrap/dist/css/bootstrap.min.css";
import uuid from "react-uuid";
class App extends Component {
    state = {
        items: [],
        id: uuid(),
        item: "",
        editItem: false
    };
    handleChange = (e) => {
        this.setState({
            item: e.target.value
        });
    };
    handleSubmit = (e) => {
        e.preventDefault();

        const newItem = {
            id: this.state.id,
            title: this.state.item
        };
        console.log(newItem);
        const updatedItems = [...this.state.items, newItem];
        this.setState({
            items: updatedItems,
            item: "",
            id: uuid(),
            editItem: false
        });
    };
    clearList = () => {
        this.setState({
            items: []
        });
    };
    handleDelete = (id) => {
        const filteredItems = this.state.items.filter((item) => item.id !== id);
        this.setState({
            items: filteredItems
        });
    };
    handleEdit = (id) => {
        const filteredItems = this.state.items.filter((item) => item.id !== id);

        const selectedItem = this.state.items.find((item) => item.id === id);

        this.setState({
            items: filteredItems,
            item: selectedItem.title,
            editItem: true,
            id: id
        });
    };

    render() {
        return (
            <div className="container">
                <div className="row">
                    <div className="col-10 mx-auto col-md-8 mt-4">
                        <h1 className="text-danger">Todo Input</h1>
                        <TodoInput
                            item={this.state.item}
                            handleChange={this.handleChange}
                            handleSubmit={this.handleSubmit}
                            editItem={this.state.editItem}
                        />
                        <TodoList
                            items={this.state.items}
                            clearList={this.clearList}
                            handleDelete={this.handleDelete}
                            handleEdit={this.handleEdit}
                        />
                    </div>
                </div>
            </div>
        );
    }
}
export default App;