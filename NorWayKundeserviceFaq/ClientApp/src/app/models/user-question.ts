import { Category } from './category';

export class UserQuestionDTO {
  id: number;
  firstname: string;
  lastname: string;
  question: string;
  categoryId: number;
}

export class UserQuestion {
  id: number;
  firstname: string;
  lastname: string;
  question: string;
  categoryId: number;
  category: Category;
}
