import React, { useState, useEffect, useRef } from 'react';

function TodoForm(props) {
  const [input, setInput] = useState(props.edit ? props.edit.value : '');
  const inputRef = useRef(null);

  //always input focus
  useEffect(() => {
    inputRef.current.focus();
  });

  //input value added to input state
  const handleChange = (e) => {
    setInput(e.target.value);
  };
  //form submit
  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.edit) {
      props.onSubmit({
        id: props.edit.id,
        text: input,
      });
      console.log(props.edit.id);
      console.log(input);
    } else {
      //added new todo with id and input value to the todolist component
      props.onSubmit({
        id: Math.floor(Math.random() * 10000),
        text: input,
      });
    }

    setInput(''); //clear input after todo added
  };

  return (
    <div>
      <form onSubmit={handleSubmit} className="todo-form">
        {props.edit ? (
          <>
            <input
              type="text"
              placeholder="Edit a todo item"
              value={input}
              name="text"
              className="todo-input edit"
              onChange={handleChange}
              ref={inputRef}
            />
            <button onSubmit={handleSubmit} className="todo-button">
              Update
            </button>
          </>
        ) : (
          <>
            <input
              type="text"
              placeholder="Add a todo item"
              value={input}
              name="text"
              className="todo-input"
              onChange={handleChange}
              ref={inputRef}
            />
            <button onSubmit={handleSubmit} className="todo-button">
              Add todo
            </button>
          </>
        )}
      </form>
    </div>
  );
}

export default TodoForm;
