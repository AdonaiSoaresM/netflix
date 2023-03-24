import Emitter from "tiny-emitter";

const EVENT_NAME = "form:toggle"

const emitter = new Emitter();

export default function useModalForm() {
  function open() {
    emitter.emit(EVENT_NAME, true);
  }

  function listen(fn) {
    emitter.on(EVENT_NAME, fn);
  }

  function close(){
    emitter.emit(EVENT_NAME, false)
  }

  return { open, listen, close };
}
