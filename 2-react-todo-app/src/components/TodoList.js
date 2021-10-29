import React, { useState } from 'react';
import TodoForm from './TodoForm';
import Todo from './Todo';
import Modal from 'react-modal';

function TodoList() {
  const [todos, setTodos] = useState(
    localStorage.getItem('todos') === null
      ? []
      : JSON.parse(localStorage.getItem('todos'))
  );

  //check will not be added same todo state
  const [modalIsOpen, setModalIsOpen] = useState(false);

  // storing the todo in the local storage
  const storeTodo = (todo) => {
    localStorage.setItem('todos', JSON.stringify(todo));
  };

  //add new todo
  const addTodo = (todo) => {
    if (!todo.text || /^\s*$/.test(todo.text)) {
      //check if input is empty or not with regex
      return;
    }
    let newTodos = [...todos];
    //if trying to add same todo on the input then show error modal
    if (newTodos.length !== 0) {
      var i = 0;
      while (i < newTodos.length) {
        if (newTodos[i].text === todo.text) {
          setModalIsOpen(true);
          return;
        }
        i++;
      }
      newTodos = [todo, ...todos];
    }
    setTodos(newTodos);
    //adding todo to localstorage
    storeTodo(newTodos);
  };

  //update todos
  const updateTodo = (todoId, newValue) => {
    //check if input is empty or not with regex
    if (!newValue.text || /^\s*$/.test(newValue.text)) {
      return;
    }
    //updating todo
    setTodos((prev) =>
      prev.map((item) => (item.id === todoId ? newValue : item))
    );
    console.log(newValue);
    const updatedTodo = todos.find((todo) => todo.id === todoId);
    updatedTodo.text = newValue.text;
    console.log(updatedTodo);
    localStorage.setItem('todos', JSON.stringify(todos));
  };

  //delete todos
  const removeTodo = (id) => {
    //return new array without deleted todo
    const removeArr = [...todos].filter((todo) => todo.id !== id);

    //deleting todo
    setTodos(removeArr);
    //deleting todo from localstorage
    localStorage.setItem('todos', JSON.stringify(removeArr));
  };

  //complete todos
  const completeTodo = (id) => {
    let updatedTodos = todos.map((todo) => {
      if (todo.id === id) {
        todo.isComplete = !todo.isComplete;
      }
      return todo;
    });
    setTodos(updatedTodos);
    localStorage.setItem('todos', JSON.stringify(updatedTodos));
  };

  return (
    <div>
      <h1>What's the task for Today?</h1>
      <TodoForm onSubmit={addTodo} />
      <Todo
        todos={todos}
        completeTodo={completeTodo}
        removeTodo={removeTodo}
        updateTodo={updateTodo}
      />
      <Modal
        className="modal"
        isOpen={modalIsOpen}
        onRequestClose={() => setModalIsOpen(false)}
      >
        <h2>Ooops!</h2>
        <p>It's look like you already add this task...</p>
        <button onClick={() => setModalIsOpen(false)}>I Know</button>
      </Modal>
    </div>
  );
}

export default TodoList;
