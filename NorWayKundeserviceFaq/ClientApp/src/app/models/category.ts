import { Question } from './question';
import { Observable } from 'rxjs';

export class Category {
  categoryId: Number;
  name: String;
  questions: Question[];
}
